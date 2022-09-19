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
  background-image: url(https://images.unsplash.com/photo-1607528926952-d4f83df2683c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1154&q=80);
  width: 100%;
  height: 30vh;
  background-position: bottom;
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
}
</style>
