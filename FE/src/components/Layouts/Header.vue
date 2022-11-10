<template>
    <div class="header-top">
        <div class="container">
            <div class="row">
                <div class="col-4"><i class="bi bi-telephone-fill"></i> +84 333 089 143</div>
                <div class="col-4"><i class="bi bi-envelope-fill"></i> nmkhoa2k@gmail.com</div>
                <div class="col-4" style="display: flex; justify-content: space-evenly;">
                    <div style=" margin-right: 1rem;"><router-link to="/login"><i class="bi bi-person-fill"></i>Đăng nhập</router-link>
                    </div>
                    <div style=" margin-right: 1rem;"><router-link to="/cart"><i class="bi bi-cart-fill"></i>Giỏ hàng</router-link>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="header-bot">
        <div class="container">
            <div class="row">
                <div class="col-2">
                    <router-link class="nav-link active fw-bold" aria-current="page" to="/">LOGO STORE</router-link>
                </div>
                <div class="col-6" style="display: flex; justify-content: space-evenly;">
                    <router-link class="nav-link active fw-bold" aria-current="page" to="/">TRANG CHỦ</router-link>
                    <router-link class="nav-link dropdown-toggle" to="/brand/all" id="navbarDropdown" role="button"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        <b>SẢN PHẨM</b>
                    </router-link>
                    <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <li><router-link class="dropdown-item" to="/category/all">Tất cả sản phẩm</router-link></li>
                        <li>
                            <hr class="dropdown-divider">
                        </li>
                        <div v-for="item in category">
                            <li><router-link class="dropdown-item" :to="'/category/' + item.url ">{{ item.name }}</router-link></li>
                        </div>
                    </ul>
                    <router-link class="nav-link active fw-bold" to="/brand/all">THƯƠNG HIỆU</router-link>
                    <router-link class="nav-link active fw-bold" to="/knowledge">KIẾN THỨC</router-link>
                </div>
                <div class="col-4">
                    <form class="d-flex">
                        <input class="form-control me-2" type="search" placeholder="Tìm kiếm..." aria-label="Search">
                        <button class="btn btn-outline-dark" type="submit"><i class="bi bi-search"></i></button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { RouterLink } from 'vue-router'
import { HTTP } from '../../http-common.js'
export default {
    data() {
        return {
            category: null
        }
    },
    mounted() {
        this.getAllCategory()
    },
    methods: {
        getAllCategory() {
            HTTP.get('Category/getAll').then(res => {
                if (res.data) {
                    this.category = res.data
                }
            })
        }
    }
}
</script>

<style scoped>
a {
    text-decoration: none;
    color: black;
}

a:hover {
    color: #22c55E;
}

.header-top {
    background-color: #f5f5f5e0;
    padding: 0.1rem 0.1rem;
}

.header-bot {
    padding: 0.5rem 0.5rem;
    background-color: #fbae40;
    position: sticky;
    top: 0;
    z-index: 2;
}

.header-bot:hover {
    background-color: #eab367;
}
</style>