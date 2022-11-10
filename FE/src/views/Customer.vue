<template>
    <Header></Header>
    <div class="container mt-4 mb-4">
        <div class="mb-4 fst-italic">
            Trang chủ / Thông tin cá nhân
        </div>
        <div class="row">
            <div class="col register">
                <div class="fs-5 fw-bold mb-4 mt-4" style="text-align: center;">Quản lý thông tin cá nhân</div>
                <div class="regis">
                    <div class="regis-box">
                        <label class="from-label mb-2">Họ và tên:</label>
                        <input class="form-control mb-4" type="text">
                        <label class="form-label mt-2">Giới tính</label>
                        <select class="form-select mb-4" aria-label="Default select example">
                            <option selected>Nam</option>
                            <option value="1">Nữ</option>
                            <option value="2">Khác</option>
                        </select>
                        <label class="from-label mb-2">Ngày sinh</label>
                        <input class="form-control mb-4" type="date">
                        <label class="from-label mb-2">Số điện thoại:</label>
                        <input class="form-control mb-4" type="number">
                        <!-- <label class="from-label mb-2">Địa chỉ:</label>
                        <input class="form-control mb-4" type="text"> -->
                        <button class="btn btn-outline-dark mb-4" data-bs-toggle="modal"
                            data-bs-target="#staticBackdrop">Lưu thay đổi</button>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="fs-5 fw-bold mb-4 mt-4" style="text-align: center;">Đổi mật khẩu</div>
                <div class="login">
                    <div class="login-box">
                        <label class="from-label mb-2">Mật khẩu cũ:</label>
                        <input class="form-control mb-4" type="password">
                        <label class="from-label mb-2">Mật khẩu mới:</label>
                        <input class="form-control mb-4" type="password">
                        <label class="from-label mb-2">Nhập lại mật khẩu mới:</label>
                        <input class="form-control mb-4" type="password">
                        <button class="btn btn-outline-warning" style="float: right;">Xác nhận</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- <div class="mt-4" style="display: flex; justify-content: space-evenly;">
            <img src="https://file.hstatic.net/1000185761/article/bung-no-uu-dai-1-1_efbfc07dc112494b8f0f0fd68a8cff91_large.jpg"
                alt="">
            <img src="https://file.hstatic.net/1000185761/article/bung-no-uu-dai-mua-cuoi-nam-rinh-ngay-keo-lo-1200x628_bed2bedc902c4349b34325711bad3b90_large.png"
                alt="">
        </div> -->


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
                        <input class="form-control" type="text" name="" id="">
                        <label class="form-label mt-2">Giới tính</label>
                        <select class="form-select" aria-label="Default select example">
                            <option selected>Nam</option>
                            <option value="1">Nữ</option>
                            <option value="2">Khác</option>
                        </select>
                        <label class="form-label mt-2">Ngày sinh</label>
                        <input class="form-control" type="datetime" name="" id="">                        
                        <label class="form-label mt-2">Số điện thoại</label>
                        <input class="form-control" type="number" name="" id="">
                        <label class="form-label mt-2">Tên tài khoản</label>
                        <input class="form-control" type="text" name="" id="">
                        <label class="form-label mt-2">Mật khẩu</label>
                        <input class="form-control" type="password" name="" id="">  
                        <label class="form-label mt-2">Nhập lại mật khẩu</label>
                        <input class="form-control" type="password" name="" id="">                       
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-outline-dark" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-outline-warning">Xác nhận</button>
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
export default {
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
    justify-content: left;
    margin-left: 7rem;
}

.regis-box{
    width: 80%;
}
</style>