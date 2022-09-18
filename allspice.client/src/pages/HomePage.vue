<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter
      </h1>
    </div>
  </div>
  <img src="https://img1.wsimg.com/isteam/ip/7e04c8bb-9bfe-4fb3-973e-a982d6844ff1/soup-garden-logo-small-web-transparentbg-0001.png" alt="Soups-up Logo" class="">
  <img src="https://www.tastingtable.com/img/gallery/40-types-of-soup-and-what-makes-them-unique/intro-1661261800.webp" alt="Soups-up Logo" class="">
  <img src="https://www.tastingtable.com/img/gallery/40-types-of-soup-and-what-makes-them-unique/pho-1661261800.webp" alt="Soups-up Logo" class="">
  <img src="https://thekitchencommunity.org/wp-content/uploads/2021/11/shutterstock_1074279785.jpg" alt="Soups-up Logo" class="">
  <img src="https://www.dailybreeze.com/wp-content/uploads/2020/02/LDN-L-DINE-SOUP-0214-1-1.jpg?w=863" alt="Soups-up Logo" class="">
  <img src="" alt="Soups-up Logo" class="">
</template>


<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
