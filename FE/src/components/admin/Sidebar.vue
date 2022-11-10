<template>
    <div class="fw-bold sidebar-title">Danh sách quản lý</div>
    <Button icon="pi pi-arrow-right" @click="visibleLeft = true" class="mr-2 p-button-success mt-2 ms-2" />
    <div class="container mt-2">
        <Sidebar v-model:visible="visibleLeft" :baseZIndex="10000">
            <h2 class="fw-bold">Mwie Store</h2>
            <div class="mt-4 mb-4" style="display: flex; justify-content: space-between; flex-direction: column;">
                <div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin"><i class="bi bi-house"></i> Trang chủ</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/user"><i class="bi bi-person"></i> Quản lý người dùng</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/brand"><i class="bi bi-bookmarks"></i> Quản lý nhà cung cấp</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/category"><i class="bi bi-tags"></i> Quản lý danh mục</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/product"><i class="bi bi-box-seam"></i> Quản lý sản phẩm</a>
                    </div>
                    <!-- <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/image"><i class="bi bi-images"></i> Quản lý hình ảnh</a>
                    </div> -->
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/order"><i class="bi bi-cart"></i> Quản lý đơn đặt hàng</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/bill"><i class="bi bi-bag-dash"></i> Quản lý hóa đơn</a>
                    </div>
                    <!-- <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/bill"><i class="bi bi-chat"></i> Quản lý bình luận</a>
                    </div>
                    <div class="mt-4 mb-4 fw-bold">
                        <a href="/admin/bill"><i class="bi bi-chat-left"></i> Quản lý đánh giá</a>
                    </div> -->
                </div>
                <hr>
                <div class="mt-4 mb-4 fw-bold">
                    <a href="/"><i class="bi bi-backspace"></i> Trở về trang mua hàng</a>
                </div>
            </div>
        </Sidebar>
    </div>
</template>

<script>
export default {
    data() {
        return {
            visibleLeft: false,
        }
    }
}
</script>

<style scoped>
a {
    text-decoration: none !important;
    color: #22c55E !important;
}

.sidebar-title {
    font-size: 25px;
    color: #22c55E;
}
</style>