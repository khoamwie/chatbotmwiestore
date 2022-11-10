<template>
  <div class="footer-dark">
    <footer>
      <div class="container">
        <div class="row">
          <div class="col-sm-6 col-md-3 item text">
            <h3>Hỗ trợ khách hàng</h3>
            <ul>
              <p>Hướng dẫn đặt hàng</p>
              <p>Hướng dẫn thanh toán</p>
              <p>Chính sách vận chuyển</p>
              <p>Chính sách bảo hành</p>
            </ul>
          </div>
          <div class="col-sm-6 col-md-3 item text">
            <h3>Liên hệ</h3>
            <ul>
              <P>Điện thoại: 0382464293 </p>
              <p>Địa chỉ: Hẻm 132,Phường Hưng Lợi, Quận Ninh Kiều, TP Cần Thơ</p>
              <p>Email: mwiestore@gmail.com</p>
            </ul>
          </div>
          <div class="col-md-6 item text">
            <h3>Mwie Store</h3>
            <p>Mwie Store luôn luôn đem lại cho bạn sự trải nghiệm tốt nhất về sản phẩm. Chất lượng, giá cả
              và dịch vụ tuyệt hảo.
              <br>
              TOP Protein and Amino Acids tốt nhất dành cho người tập Gym được bán Mwie Store.
            </p>
          </div>
          <div class="col item social">
            <a href="#"><i class="bi bi-facebook"></i></a>
            <a href="#"><i class="bi bi-twitter"></i></a>
            <a href="#"><i class="bi bi-snapchat"></i></a>
            <a href="#"><i class="bi bi-instagram"></i></a>
          </div>
        </div>
        <!-- <p class="copyright">Mwie Store © 2022</p> -->
      </div>
    </footer>
  </div>
</template>

<script>

</script>

<style>
.footer-dark {
  padding: 2rem 2rem;
  color: #f0f9ff;
  background-color: #282d32;
}

.footer-dark h3 {
  margin-top: 0;
  margin-bottom: 12px;
  font-weight: bold;
  font-size: 16px;
}

.footer-dark ul {
  padding: 0;
  list-style: none;
  line-height: 1.6;
  font-size: 14px;
  margin-bottom: 0;
}

.footer-dark ul a {
  color: inherit;
  text-decoration: none;
  opacity: 0.6;
}

.footer-dark ul a:hover {
  opacity: 0.8;
}

@media (max-width:767px) {
  .footer-dark .item:not(.social) {
    text-align: center;
    padding-bottom: 20px;
  }
}

.footer-dark .item.text {
  margin-bottom: 36px;
}

@media (max-width:767px) {
  .footer-dark .item.text {
    margin-bottom: 0;
  }
}

.footer-dark .item.text p {
  opacity: 0.6;
  margin-bottom: 0;
}

.footer-dark .item.social {
  text-align: center;
}

@media (max-width:991px) {
  .footer-dark .item.social {
    text-align: center;
    margin-top: 20px;
  }
}

.footer-dark .item.social>a {
  font-size: 20px;
  width: 36px;
  height: 36px;
  line-height: 36px;
  display: inline-block;
  text-align: center;
  border-radius: 50%;
  box-shadow: 0 0 0 1px rgba(255, 255, 255, 0.4);
  margin: 0 8px;
  color: #fff;
  opacity: 0.75;
}

.footer-dark .item.social>a:hover {
  opacity: 0.9;
}

.footer-dark .copyright {
  text-align: center;
  padding-top: 24px;
  opacity: 0.3;
  font-size: 13px;
  margin-bottom: 0;
}
</style>