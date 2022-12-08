<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / chi tiết sản phẩm
        </div>
        <div class="row mt-4">
            <div class="col">
                <Galleria :value="image" :responsiveOptions="responsiveOptions" :numVisible="3"
                    containerStyle="max-width: 640px">
                    <template #item="slotProps">
                        <img :src="'/src/assets/images/' + slotProps.item.url + '.png'" :alt="slotProps.item.alt"
                            style="width: 50%" />
                    </template>
                    <template #thumbnail="slotProps">
                        <img :src="'/src/assets/images/' + slotProps.item.url + '.png'" :alt="slotProps.item.alt"
                            style="width: 70%" />
                    </template>
                </Galleria>
                <!-- <Image :src="'/src/assets/images/' + product.image + '.png'" alt="{{product.id}}" width="400" preview/> -->
            </div>
            <div class="col">
                <label class="form-label mb-2 fw-bold fs-3" style="color: #fbae40;">Thông tin sản phẩm</label>
                <div class="mt-4" style="margin-left: 2rem;">
                    <label class="form-label mb-2 fs-5"><b style="color: #fbae40;">Tên sản phẩm:</b> {{ product.name
                    }}</label><br>
                    <label class="form-label mb-2 fs-5"><b style="color: #fbae40;">Hãng sản xuất:</b> {{ brand.name
                    }}</label><br>
                    <label class="form-label mb-2 fs-5"><b style="color: #fbae40;">Dạng:</b> {{ product.type
                    }}</label><br>
                    <label class="form-label mb-2 fs-5">
                        <div class="row">
                            <div class="col">
                                <div class="fw-bold" style="color: #fbae40;">Giá:</div>
                            </div>
                            <div class="col">
                                <div :hidden="hiddendiscountnum" class="text-decoration-line-through">{{ product.price
                                }}đ</div>
                            </div>
                            <div class="col">
                                <div class="">{{ this.discount }}đ</div>
                            </div>
                            <div class="col">
                                <div :hidden="hiddendiscountnum" class="" style="color: red"> -{{ this.discountnum }}%
                                </div>
                            </div>
                        </div>
                    </label><br>
                    <!-- <label class="form-label mb-2 fs-5"><b style="color: #fbae40;">HSD:</b> {{ i.endDate }}
                        đ</label><br> -->

                    <label class="form-label mb-2 fs-5"><b style="color: #fbae40;">Số lượng: &nbsp;</b></label>
                    <InputNumber v-model="number" mode="decimal" showButtons :min="0" :max="10" /><br>
                    <Button class="p-button-warning p-button-sm mt-4" label="Thêm vào giỏ hàng"
                        icon="pi pi-shopping-cart" @click="addCard"></Button>
                </div>
            </div>
        </div>
        <div class="mt-4">
            <TabView ref="tabview1">
                <TabPanel header="Mô tả sản phẩm">
                    <p>{{ product.description }}</p>
                </TabPanel>
                <TabPanel header="Bình luận">
                    <div class="fw-bold">
                        <p>Nhập bình luận của bạn tại đây:</p>
                        <Textarea v-model="value" rows="5" cols="100" />
                        <div class="">
                            <Button class="p-button-warning p-button-sm" label="Xác nhận"></Button>
                        </div>
                    </div>
                    <div class="">

                    </div>
                </TabPanel>
                <TabPanel header="Đánh giá ">
                    <div class="fw-bold">
                        <!-- <p>Nhập đánh giá của bạn tại đây:</p>
                        <div class="mb-4">
                            <Rating v-model="rt" :cancel="false" />
                        </div>
                        <Textarea v-model="value" rows="5" cols="100" maxlength="100"/>
                        <div class="">
                            <Button class="p-button-warning p-button-sm" label="Xác nhận"></Button>
                        </div> -->
                    </div>
                    <div class="">

                    </div>
                </TabPanel>
            </TabView>
        </div>
    </div>
    <Footer></Footer>
</template>

<script>
import Header from "../components/Layouts/Header.vue";
import Footer from "../components/Layouts/Footer.vue";
import { HTTP } from "../http-common.js"
import router from "../router";
export default {
    data() {
        return {
            product: {},
            brand: {},
            image: [],
            rt: 0,
            number: 0,
            userid: null,
            discount: null,
            discountnum: null,
            hiddendiscountnum: true
        }
    },
    mounted() {
        this.userid = localStorage.getItem('userid')
        this.getProductbyId()

    },
    methods: {
        formatDate(value) {
            return value.toLocaleDateString('en-US', {
                day: '2-digit',
                month: '2-digit',
                year: 'numeric',
            });
        },
        async getProductbyId() {
            await HTTP.get('Product/' + this.$route.params.id).then(res => {
                if (res.data) {
                    this.product = res.data
                    // this.product.push(res.data)
                    this.getBrandbyProductId(this.product.brand_id)
                    this.getImagebyProductId(this.product.id)
                    this.getDiscoutbyProductId()
                }
            })
        },
        getBrandbyProductId(id) {
            HTTP.get('Brand/' + this.product.brand_id).then(res => {
                if (res.data) {
                    this.brand = res.data
                }
            })
        },
        getImagebyProductId(id) {
            HTTP.get('Image/' + this.product.id).then(res => {
                if (res.data) {
                    this.image = res.data
                }
            })
        },
        addCard() {
            HTTP.get('Bill/getIdByUserId/' + this.userid + '&' + 0).then(res => {
                if (res.data) {
                    const billid = res.data
                    if (this.number > 0) {
                        HTTP.post('BillDetail/addCard', {
                            bill_id: billid.id,
                            product_id: this.$route.params.id,
                            number: this.number
                        }).then(res => {
                            if (res.status == 200) {
                                this.card = res.data
                                alert('Them san pham vao gio hang thanh cong')
                                router.push('/')
                            }
                        })
                    }else{
                        alert('Vui long chon so luong')
                        location.reload()
                    }
                }

            })
        },
        getDiscoutbyProductId() {
            HTTP.get('PromotionDetail/CheckPromotion/' + this.product.id).then(res => {
                if (res.data) {
                    // console.log(res.data[0].discount)
                    if (res.data.length > 0) {
                        this.discountnum = res.data[0].discount
                        this.discount = (this.product.price * res.data[0].discount) / 100
                        this.hiddendiscountnum = false
                    } else {
                        this.hiddendiscountnum = true
                        this.discount = this.product.price
                    }
                }
            })
        }
    },
    components: { Header, Footer }
}
</script>

<style>

</style>

