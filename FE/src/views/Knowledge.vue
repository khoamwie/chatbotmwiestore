<template>
    <Header></Header>
    <div class="text-link">
        <div class="mb-4 fst-italic mt-4">
            Trang chủ / Kiến thức
        </div>
    </div>
    <div class="container mt-4 mb-4">
        <figure class="snip0019">
            <img src="/src/assets/images/404.png" alt="404" />
            <figcaption>
                <div>
                    <h2><span>SORRY!!!</span></h2>
                </div>
                <div>
                    <p>Chức năng này hiện đang được phát triển. Hãy trở lại trong thời gian tới!!!</p>    
                </div>
                <a href="#"></a>
            </figcaption>
        </figure>
    </div>
    <Footer></Footer>
</template>

<script>
import Header from '../components/Layouts/Header.vue'
import Footer from '../components/Layouts/Footer.vue'
export default {
    components: { Header, Footer }
}
</script>

<style lang="scss" scoped>
.text-link {
    margin-left: 7rem;
}

.container{
    width: 100%;
    display: flex;
    justify-content: center;
}

@import url(https://fonts.googleapis.com/css?family=Raleway:400,200,300,800);
figure.snip0019 {
  font-family: 'Raleway', Arial, sans-serif;
  color: #fff;
  position: relative;
  overflow: hidden;
  margin: 10px;
  min-width: 220px;
  max-width: 960px;
  max-height: 540px;
  width: 100%;
  background: #000000;
  text-align: center;
}
figure.snip0019 * {
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
}
figure.snip0019 img {
  opacity: 1;
  width: 100%;
  -webkit-transition: opacity 0.35s;
  transition: opacity 0.35s;
}
figure.snip0019 figcaption {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  text-align: left;
}
figure.snip0019 figcaption > div {
  float: left;
  height: 100%;
  overflow: hidden;
  width: 50%;
  position: relative;
}
figure.snip0019 figcaption::before {
  position: absolute;
  top: 50%;
  bottom: 50%;
  left: 50%;
  width: 2px;
  content: '';
  opacity: 0;
  background-color: rgba(255, 255, 255, 0);
  -webkit-transition: all 0.4s;
  transition: all 0.4s;
  -webkit-transition-delay: 0.6s;
  transition-delay: 0.6s;
}
figure.snip0019 h2,
figure.snip0019 p {
  margin: 0;
  padding: 20px;
  opacity: 0;
  position: absolute;
  top: 0;
  width: 100%;
  left: 0;
  -webkit-transition: opacity 0.45s, -webkit-transform 0.45s;
  transition: opacity 0.45s,-webkit-transform 0.45s,-moz-transform 0.45s,-o-transform 0.45s,transform 0.45s;
  font-size: 25px;
  font-weight: bold;
}
figure.snip0019 h2 {
  text-align: right;
  display: inline-block;
  word-spacing: -0.1em;
  font-weight: 300;
  text-transform: uppercase;
  bottom: 0;
  background: rgba(0, 0, 0, 0.5);
  -webkit-transform: translate3d(50%, 0%, 0);
  transform: translate3d(50%, 0%, 0);
  -webkit-transition-delay: 0s;
  transition-delay: 0s;
}
figure.snip0019 h2 span {
  font-weight: 800;
}
figure.snip0019 p {
  display: block;
  bottom: 0;
  text-align: left;
  font-weight: 300;
  top: 0%;
  color: #000;
  background: #ffffff;
  -webkit-transform: translate3d(-50%, 0%, 0);
  transform: translate3d(-50%, 0%, 0);
  -webkit-transition-delay: 0s;
  transition-delay: 0s;
}
figure.snip0019 a {
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  position: absolute;
  color: #ffffff;
}
figure.snip0019:hover img {
  opacity: 0.7;
}
figure.snip0019:hover figcaption h2,
figure.snip0019:hover figcaption p {
  -webkit-transform: translate3d(0%, 0%, 0);
  transform: translate3d(0%, 0%, 0);
  -webkit-transition-delay: 0.3s;
  transition-delay: 0.3s;
}
figure.snip0019:hover figcaption h2 {
  opacity: 1;
}
figure.snip0019:hover figcaption p {
  opacity: 1;
}
figure.snip0019:hover figcaption::before {
  background: #ffffff;
  top: 0px;
  bottom: 0px;
  opacity: 1;
  -webkit-transition-delay: 0s;
  transition-delay: 0s;
}


/* Demo purposes only */
html {
  height: 100%;
}
body {
  background-color: #212121;
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0;
  height: 100%;
}
</style>