<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Giỏ hàng
        </div>
        <div>
            <DataTable :value="card" :paginator="false" class="p-datatable-customers" :rows="10" dataKey="id"
                :rowHover="true" v-model:selection="selectedCustomers" v-model:filters="filters" filterDisplay="menu"
                paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                :rowsPerPageOptions="[10, 25, 50]"
                currentPageReportTemplate="Showing {first} to {last} of {totalRecords} entries"
                responsiveLayout="scroll">
                <template #header>
                    <div class="header-table">
                        <div class="fw-bold fs-5 mt-2 mb-2" style="color: #fbae40;"><i class="bi bi-cart3"></i> Giỏ hàng
                        </div>
                        <div>
                            <Button class="p-button-sm p-button-outlined p-button-warning" label="Cập nhật giỏ hàng"
                                @click="updateCard123" />
                        </div>
                    </div>
                </template>
                <template #empty>
                    Không tìm sản phẩm.
                </template>
                <Column field="tenSanPham" header="Tên sản phẩm" sortable>
                    <template #body="{ data }">
                        {{ data.tenSanPham }}
                    </template>
                </Column>
                <Column field="soLuong" header="Số lượng" sortable>
                    <template #body="{ data }">
                        <InputNumber inputId="minmax-buttons" v-model="data.soLuong" mode="decimal" showButtons :min="0"
                            :max="100" width="10" />
                    </template>
                </Column>
                <Column field="gia" header="Giá" sortable style="min-width: 5rem;">
                    <template #body="{ data }">
                        {{ data.gia }} <span>vnđ</span>
                    </template>
                </Column>
                <Column field="" header="">
                    <template #body="{ data }">
                        <Button class="p-button-danger p-button-rounded" icon="pi pi-trash" @click="deleteCard" />
                    </template>
                </Column>
            </DataTable>
        </div>
        <div class="mt-4 button-cart">
            <Button class="p-button-sm p-button-outlined p-button-warning" label="Tiến hành thanh toán" @click="pay" />
        </div>
    </div>
    <Footer></Footer>
</template>

<script>
import { FilterMatchMode } from 'primevue/api'
import Header from "../components/Layouts/Header.vue";
import Footer from "../components/Layouts/Footer.vue";
import { HTTP } from '../http-common.js'
import router from '../router';
export default {
    data() {
        return {
            card: null,
            product: null,
            userid: null,
            filters: {
                'global': { value: null, matchMode: FilterMatchMode.CONTAINS }
            },
        }
    },
    mounted() {
        this.userid = localStorage.getItem('userid')
        this.getBillIdbyUserId()
    },
    methods: {
        getBillIdbyUserId() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const bill_id = res.data
                    // console.log(bill_id)
                    HTTP.get('BillDetail/getBillDetail/' + bill_id.id + '&' + this.userid + '&' + 0).then(res => {
                        if (res.data) {
                            this.card = res.data
                            //console.log(this.card[0].gia)
                            for(let i = 0; i < this.card.length; i++){
                                HTTP.get('PromotionDetail/CheckPromotion/' + this.card[i].idSanPham).then(res => {
                                    if(res.data && res.data.length > 0){
                                        this.card[i].gia = (this.card[i].gia*res.data[0].discount)/100
                                    }
                                })    
                            }
                        }
                    })
                }
            })
        },
        pay() {
            router.push('/pay/' + this.userid)
        },
        updateCard123() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const bill_id = res.data
                    this.card.forEach(element => {
                        HTTP.put('BillDetail/UpdateNumberCard/' + bill_id.id + '&' + element.idSanPham + '&' + element.soLuong)
                    });
                    location.reload()
                }
            })
        },
        deleteCard() {
            HTTP.get('Bill/getIdbyUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const billid = res.data.id
                    this.card.forEach(element => {
                        HTTP.delete('BillDetail/deleteCard/' + billid + '&' + element.idSanPham)
                    })
                    alert('Xoa san pham thanh cong')
                    location.reload()
                }
            })

        }
    },
    components: { Header, Footer }
}
</script>

<style lang="scss" scoped>
.button-cart {
    display: flex;
    justify-content: right;
}

.col-right {
    flex: 1;
}

.row {
    margin-right: 0 !important;
}

.header-table {
    display: flex;
    justify-content: space-between;
}

::v-deep(.p-paginator) {
    .p-paginator-current {
        margin-left: auto;
    }
}

::v-deep(.p-progressbar) {
    height: .5rem;
    background-color: #D8DADC;

    .p-progressbar-value {
        background-color: #607D8B;
    }
}

::v-deep(.p-datepicker) {
    min-width: 25rem;

    td {
        font-weight: 400;
    }
}

::v-deep(.p-datatable.p-datatable-customers) {
    .p-datatable-header {
        padding: 1rem;
        text-align: left;
        font-size: 1.5rem;
    }

    .p-paginator {
        padding: 1rem;
    }

    .p-datatable-thead>tr>th {
        text-align: left;
    }

    .p-datatable-tbody>tr>td {
        cursor: auto;
    }

    .p-dropdown-label:not(.p-placeholder) {
        text-transform: uppercase;
    }
}
</style>

