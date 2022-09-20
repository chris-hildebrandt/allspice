<template>
  <header>
    <div class="col banner"></div>
  </header>
  <Navbar />
  <main>
    <router-view />
  </main>
  <footer>
  </footer>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from './AppState';

export default {
  name: 'App',
  setup() {
    onMounted(()=>{
      
    })
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
.banner{
  background-image: url(https://d3ox4wjkl7mf3m.cloudfront.net/feed_stories/IWqh0TzkJnq1InIDdtNhZkWOWLotPdWeZK697FFu.jpeg);
  width: 100%;
  height: 40vh;
  background-position: 50% -100px;
  background-repeat: no-repeat;
  background-size: contain;
  background-attachment: fixed;
}

</style>
