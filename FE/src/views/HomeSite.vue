<template>
  <Header></Header>
  <!-- <Chat></Chat> -->
  <div class="container mt-4 mb-4">

    <Slider></Slider>
    <div class="mt-4 mb-4 fs-3 fw-bold" style="text-align: center; color: #fbae40;"><i class="bi bi-stars"></i><i class="bi bi-stars"></i> HÃY ĐẾN VỚI MWIE STORE <i class="bi bi-stars"></i><i class="bi bi-stars"></i></div>
    <!-- Why me? -->
    <div class="content-2 mt-4">
      <div class="row">
        <div class="col-lg-4">
          <img src="/src/assets/images/free-ship.png" alt="">
          <p>GIAO HÀNG MIỄN PHÍ</p>
          <p>Giao hàng toàn quốc</p>
          <p>Đơn hàng trên 800.000đ</p>
        </div>
        <div class="col-lg-4">
          <img src="/src/assets/images/quality.png" alt="">
          <P>UY TÍNH VÀ CHẤT LƯỢNG</P>
          <p>100% sản phẩm chính hãng</p>
          <p>Thanh toán khi nhận hàng</p>
        </div>
        <div class="col-lg-4">
          <img src="/src/assets/images/support.png" alt="">
          <P>HỖ TRỢ KHÁCH HÀNG</P>
          <p>Hỗ trợ 24/7</p>
          <P>Hotline: +84 33 089 143</P>
        </div>
      </div>
    </div>
    <!-- // -->

    <!-- Top product -->
    <div class="mt-4 mb-4 fs-5 fw-bold" style="text-align: left; color: #fbae40;"><i class="bi bi-box-seam"></i> SẢN PHẨM NỔI BẬT</div>
    <div class="mb-4">
      <Carousel :value="products" :numVisible="3" :numScroll="1"
        class="custom-carousel" :circular="true" :autoplayInterval="3000">
        <template #header>
          &nbsp;
        </template>
        <template #item="slotProps">
          <div class="product-item">
            <div class="product-item-content">
              <div class="mb-3">
                <img :src="'src/assets/images/' + slotProps.data.images + '.PNG'" class="product-image" />
              </div>
              <div>
                <h4 class="mb-1">{{ slotProps.data.name }}</h4>
                <h6 class="mt-0 mb-3">{{ slotProps.data.price }}Vnđ</h6>
                <div class="car-buttons mt-5">
                  <Button icon="pi pi-search" class="p-button p-button-rounded mr-2" />
                  <Button icon="pi pi-star-fill" class="p-button-success p-button-rounded mr-2" />
                  <Button icon="pi pi-shopping-cart" class="p-button-help p-button-rounded" />
                </div>
              </div>
            </div>
          </div>
        </template>
      </Carousel>
    </div>
    <div style="text-align: center;"><button class="btn btn-outline-warning" style="width: 20%;" @click="categoryAll">Xem thêm</button></div>
    <!-- // -->

    <!-- thuong hieu noi bat -->
    <div class="mt-4 mb-4 fs-5 fw-bold" style="text-align: left; color: #fbae40;"><i class="bi bi-tags"></i> NHÀ CUNG CẤP NỔI BẬT</div>
    <div class="mb-4">
      <Carousel :value="brands" :numVisible="3" :numScroll="1" class="custom-carousel" :circular="true"
        :autoplayInterval="3000">
        <template #header>
          &nbsp;
        </template>
        <template #item="slotProps">
          <div class="product-item">
            <div class="product-item-content">
              <div class="mb-3">
                <img :src="'src/assets/images/' + slotProps.data.images + '.PNG'" class="product-image" />
              </div>
              <div>
                <h4 class="mb-1">{{ slotProps.data.name }}</h4>
              </div>
            </div>
          </div>
        </template>
      </Carousel>
    </div>
    <div style="text-align: center;"><button class="btn btn-outline-warning" style="width: 20%;" @click="brandAll">Xem thêm</button></div>
    <!-- // -->

    <!-- Kiến thức -->
    <div class="mt-4 mb-4 fs-5 fw-bold" style="text-align: left; color: #fbae40;" hidden="true"><i class="bi bi-files" ></i> KIẾN THỨC THỂ THAO</div>
    <!-- // -->
  </div>
  <Footer></Footer>
</template>

<script>
import { HTTP } from '../http-common.js'
import router from '../router/index.js'
import Header from '../components/Layouts/Header.vue'
import Footer from '../components/Layouts/Footer.vue'
import Slider from '../components/Layouts/Slider.vue'
import Chat from '../components/Buttons/Chat.vue'

export default {
  data() {
    return {
      brands: null,
      products: [
        {name: 'Sữa Tăng Cơ Giảm Mỡ Applied Nutrition ISO-XP 1.8kg - 72 Lần Dùng', images: 'product_1', price: '1,785,000 '},
        {name: 'Viên Uống Đốt Mỡ Không Chất Kích Thích Nutrex Lipo-6 Black Stim-Free 60 Viên', images: 'product_2', price: '800,000 '},
        {name: 'Sữa Tăng Cơ Giảm Mỡ Rule One Protein R1 Protein 2.27kg', images: 'product_3', price: '1,800,000 '},
        {name: 'BPI ISO HD 4.8lbs (2.17kg) - 100% Pure Whey Protein Isolate, 3 Mùi', images: 'product_4', price: '1,598,000 '},
        {name: 'Viên Uống Đốt Mỡ Giảm Cân PLATINUM PURE CLA 90 Viên', images: 'product_5', price: '550,000 '},
        {name: 'Viên Uống Giảm Cân Coenzyme Q10 100% Premium - 30 Viên', images: 'product_6', price: '690,000 '}
      ],
    }
  },
  mounted() {
    this.getAllBrands()
  },
  methods: {
    getAllBrands() {
      HTTP.get('Brand/getAll').then(res => {
        if (res.data) {
          this.brands = res.data
        }
      })
    },
    brandAll(){
      router.push('/brand/all')
    },
    categoryAll(){
      router.push('/category/all')
    }
  },
  components: { Header, Footer, Slider, Chat }
}
</script>

<style lang="scss" scoped>
.content-2 {
  text-align: center;
}

.content-3 {
  display: flex;
}

.col-lg-3 {
  display: flex;
  justify-content: center;
}

.product-item {
  .product-item-content {
    border: 1px solid var(--surface-border);
    border-radius: 3px;
    margin: .3rem;
    text-align: center;
    padding: 2rem 0;
  }

  .product-image {
    width: 50%;
    box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23)
  }
}
</style>