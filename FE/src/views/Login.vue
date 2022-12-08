<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Đăng nhập
        </div>
        <div class="row">
            <div class="col register">
                <div class="fs-5 fw-bold mb-4 mt-4" style="text-align: center;">Nếu bạn chưa có tài khoản, hãy ấn nút
                    bên dưới</div>
                <div class="regis">
                    <div class="regis-box">
                        <button class="btn btn-outline-dark" data-bs-toggle="modal"
                            data-bs-target="#staticBackdrop">Đăng ký tài khoản ngay</button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="fs-5 fw-bold mb-4 mt-4" style="text-align: center;">Đăng nhập</div>
                <div class="login">
                    <div class="login-box">
                        <label class="from-label mb-2">Tên tài khoản</label>
                        <input class="form-control mb-4" type="text" v-model="username">
                        <label class="from-label mb-2">Mật khẩu</label>
                        <input class="form-control mb-4" type="password" v-model="password">
                        <button class="btn btn-outline-warning" style="float: right;" @click="login">Đăng nhập</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="mt-4" style="display: flex; justify-content: space-evenly;">
            <img src="https://file.hstatic.net/1000185761/article/bung-no-uu-dai-1-1_efbfc07dc112494b8f0f0fd68a8cff91_large.jpg"
                alt="">
            <img src="https://file.hstatic.net/1000185761/article/bung-no-uu-dai-mua-cuoi-nam-rinh-ngay-keo-lo-1200x628_bed2bedc902c4349b34325711bad3b90_large.png"
                alt="">
        </div>


        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
            aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title fw-bold" id="staticBackdropLabel">Đăng ký tài khoản</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <label class="form-label mt-2">Họ và Tên</label>
                        <input class="form-control" type="text" name="" id="" v-model="name">
                        <label class="form-label mt-2">Giới tính</label>
                        <select class="form-select" v-model="gender">
                            <option selected>Nam</option>
                            <option value="1">Nữ</option>
                            <!-- <option value="2">Khác</option> -->
                        </select>
                        <label class="form-label mt-2">Ngày sinh</label>
                        <input class="form-control" type="date" name="" id="" v-model="birthdate">
                        <label class="form-label mt-2">Số điện thoại</label>
                        <input class="form-control" type="text" name="" id="" v-model="phone" maxlength="10">
                        <label class="form-label mt-2">Tên tài khoản</label>
                        <input class="form-control" type="text" name="" id="" v-model="username" maxlength="20">
                        <label class="form-label mt-2">Mật khẩu</label>
                        <input class="form-control" type="password" name="" id="" v-model="password" maxlength="20">
                        <label class="form-label mt-2">Nhập lại mật khẩu</label>
                        <input class="form-control" type="password" name="" id="" v-model="repassword" maxlength="20">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-outline-dark" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-outline-warning" @click="signin">Xác nhận</button>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <Footer></Footer>
</template>

<script>
import Header from '../components/Layouts/Header.vue';
import Footer from '../components/Layouts/Footer.vue';
import router from '../router/index.js'
import { HTTP } from '../http-common.js'
export default {
    data() {
        return {
            userlogin: null,
            username: null,
            password: null,
            usersignin: null

        }
    },
    mounted() {

    },
    methods: {
        login() {
            HTTP.post('User/Login', {
                username: this.username,
                password: this.password
            }).then(res => {
                if (res.data) {
                    this.userlogin = res.data
                    localStorage.setItem("userid", this.userlogin.id)
                    localStorage.setItem("name", this.userlogin.name)
                    localStorage.setItem("role", this.userlogin.role)
                    router.push('/')
                }
            })
        },
        signin() {
            if (this.repassword == this.password) {
                HTTP.post('User/addUser', {
                    name: this.name,
                    gender: this.gender == 'Nam' ? 0 : 1,
                    birthdate: this.birthdate,
                    phone: this.phone,
                    username: this.username,
                    password: this.password
                }).then(res => {
                    try {
                        if (res.status == 200) {
                            this.usersignin = res.data
                            alert('Dang ky thanh cong')
                            location.reload()

                        }
                    } catch (error) {
                        alert('Ten tai khoan bi trung')
                    }
                })
            } else {
                alert('Nhap lai password khong dung')
            }
        },
    },
    components: { Header, Footer }
}
</script>

<style>
.register {
    background-color: #fbae40;
}

.login {
    display: flex;
    justify-content: center;
}

.login-box {
    width: 50%;
}

.regis {
    display: flex;
    justify-content: center;
}
</style>