<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / detail
        </div>
        <div class="fs-4 fw-bold text-center">CHI TIẾT SẢN PHẨM</div>
        <div class="row mt-4">
            <div class="col">
                <Galleria :value="images" :responsiveOptions="responsiveOptions" :numVisible="5"
                    containerStyle="max-width: 640px">
                    <template #item="slotProps">
                        <img :src="slotProps.item.itemImageSrc" :alt="slotProps.item.alt" style="width: 100%" />
                    </template>
                    <template #thumbnail="slotProps">
                        <img :src="slotProps.item.thumbnailImageSrc" :alt="slotProps.item.alt" />
                    </template>
                </Galleria>
            </div>
            <div class="col">
                <label class="from-label mb-2"></label>
            </div>
        </div>
    </div>
    <Footer></Footer>
</template>

<script>
import Header from "../components/Layouts/Header.vue";
import Footer from "../components/Layouts/Footer.vue";
export default {
    components: { Header, Footer }
}
</script>

<style>

</style>

