<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Thanh toán
        </div>
        <div class="fw-bold fs-3" style="color: #fbae40;">HOÀN THÀNH CÁC BƯỚC SAU ĐỂ THANH TOÁN THÀNH CÔNG</div>
        <div class="profile">
            <div class="fw-bold fs-4" style="color: #fbae40;">B1: Xác nhận thông tin:</div>
            <div class="row">
                <div class="col">Họ và tên: {{ user.name }}</div>
                <div class="col">Giới tính: {{ getGender(user.gender) }}</div>
                <div class="col">Số điện thoại: {{ user.phone }}</div>
                <div class="col">Tổng giá tiền: {{ total }} <span>vnđ</span></div>
            </div>
        </div>
        <div class="mt-4 mb-4">
            <DataTable :value="card" :paginator="false" class="p-datatable-customers" :rows="10" dataKey="id"
                :rowHover="true" v-model:selection="selectedCustomers" v-model:filters="filters" filterDisplay="menu"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[10, 25, 50]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #empty>
                    Không tìm sản phẩm.
                </template>
                <Column field="tenSanPham" header="Tên sản phẩm">
                    <template #body="{ data }">
                        {{ data.tenSanPham }}
                    </template>
                </Column>
                <Column field="soLuong" header="Số lượng">
                    <template #body="{ data }">
                        {{ data.soLuong }}
                    </template>
                </Column>
                <Column field="gia" header="Giá" style="min-width: 5rem;">
                    <template #body="{ data }">
                        {{ data.gia }} <span>vnđ</span>
                    </template>
                </Column>
            </DataTable>
        </div>
        <div class="mt-4 mb-4">
            <div class="fw-bold fs-4 mb-2" style="color: #fbae40;">B2: Nhập địa chỉ giao hàng: </div>
            <InputText type="text" style="width: 50%" v-model="address" />
            <div class="fw-bold fs-4 mt-4" style="color: #fbae40;">B3: Chọn phương thức thanh toán: </div>
            <!-- <div v-for="category of categories" :key="category.key" class="field-radiobutton">
                <RadioButton name="category" :value="category.name" v-model="selectedCategory" />
                <label>{{ category.name }}</label>
            </div> -->
        </div>
        <div style="display: flex;">
            <!-- paypal -->
            <div v-if="!paidFor">
                <Button class="p-button-sm p-button-warning" label="Thanh toán trực tuyến" @click="paymethod"></Button>
                <div class="mt-4" ref="paypal"></div>
            </div>
            <div v-if="paidFor">
                <div class="fw-bold fs-5" style="color: #fbae40;"> <span><i class="bi bi-stars"></i></span>Chúc mừng bạn đã thanh toán thành công<i class="bi bi-stars"></i></div>
                <div class="fw-bold fs-5 mb-4" style="color: #fbae40;">Vui lòng ấn vào nút bên dưới để hoàn tất thanh toán</div>
                <Button class="p-button-sm p-button-warning" label="Hoàn tất thanh toán"
                    @click="confirmBillOnline"></Button>
            </div>
            <!-- // -->
            <div class="ml-4" v-if="!paidFor">
                <Button class="p-button-sm p-button-warning" label="Thanh toán khi nhận hàng"
                    @click="confirmBill"></Button>
            </div>
        </div>
    </div>
    <Footer></Footer>
</template>

<script>
import { HTTP } from '../http-common.js'
import router from '../router/index.js'
import Header from '../components/Layouts/Header.vue'
import Footer from '../components/Layouts/Footer.vue'
export default {
    data() {
        return {
            userid: null,
            user: {},
            card: null,
            total: null,
            categories: [
                { name: 'Thanh toán trực tuyến' },
                { name: 'Thanh toán khi nhận hàng' }
            ],
            selectedCategory: null,
            loaded: false,
            paidFor: false,
        }
    },
    mounted() {
        this.userid = localStorage.getItem('userid')
        this.getUserbyId()
        this.getBillIdbyUserId()

        //-------- paypal ------------------------
        // const script = document.createElement("script")
        // script.src = "https://www.paypal.com/sdk/js?client-id=Ad7EvkBH2djCVqdn5pMx3xuY2RiS41jsniIlXi_1XS5yJFdnVSqpI4KhRBuVCUlaJ2exA-sHFLq6co5M"
        // script.addEventListener("load", this.setLoaded)
        // document.body.appendChild(script)
        // --------------------------------------
    },
    methods: {
        getUserbyId() {
            HTTP.get('User/' + this.userid).then(res => {
                if (res.data) {
                    this.user = res.data
                }
            })
        },
        getBillIdbyUserId() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const bill_id = res.data
                    // console.log(bill_id)
                    HTTP.get('BillDetail/getBillDetail/' + bill_id.id + '&' + this.userid + '&' + 0).then(async res => {
                        if (res.data) {
                            this.card = res.data
                            //console.log(this.card[0].gia)
                            for(let i = 0; i < this.card.length; i++){
                                await HTTP.get('PromotionDetail/CheckPromotion/' + this.card[i].idSanPham).then(res => {
                                    if(res.data && res.data.length > 0){
                                        this.card[i].gia = (this.card[i].gia*res.data[0].discount)/100
                                    }
                                })
                                this.total += this.card[i].gia    
                            }
                        }
                    })
                }
            })
        },
        getGender(value) {
            if (value = '0') {
                return "Nam"
            } else {
                return "Nữ"
            }
        },
        confirmBill() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const bill_id = res.data
                    HTTP.put('Bill/Payment/' + bill_id.id + '&' + this.userid + '&' + this.address).then(() => {
                        alert('Vui lòng chờ xác nhận đơn hàng')
                        router.push('/')
                        // location.reload()
                    })
                }
            })
        },
        confirmBillOnline() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const bill_id = res.data
                    HTTP.put('Bill/Payment/' + bill_id.id + '&' + this.userid + '&' + this.address).then(() => {
                        alert('Bạn đã thanh toán thành công')
                        router.push('/')
                        // location.reload()
                    })
                }
            })
        },
        setLoaded() {
            this.loaded = true;
            window.paypal
                .Buttons({
                    createOrder: (data, actions) => {
                        return actions.order.create({
                            purchase_units: [
                                {
                                    // description: this.product.description,
                                    amount: {
                                        currency_code: "USD",
                                        value: this.total
                                    }
                                }
                            ]
                        });
                    },
                    onApprove: async (data, actions) => {
                        const order = await actions.order.capture();
                        this.paidFor = true;
                        console.log(order);
                    },
                    onError: err => {
                        console.log(err);
                    }
                })
                .render(this.$refs.paypal);
        },
        paymethod() {
            const script = document.createElement("script")
            script.src = "https://www.paypal.com/sdk/js?client-id=Ad7EvkBH2djCVqdn5pMx3xuY2RiS41jsniIlXi_1XS5yJFdnVSqpI4KhRBuVCUlaJ2exA-sHFLq6co5M"
            script.addEventListener("load", this.setLoaded)
            document.body.appendChild(script)
        },
        formatVND(value){
            return value/24000
        }
    },
    components: { Header, Footer }
}
</script>

<style>

</style>