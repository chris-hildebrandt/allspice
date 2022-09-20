<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-light px-3 sticky-top">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="https://cdn3.iconfinder.com/data/icons/food-set-2-1/91/Food_C138-512.png" height="45" />
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto align-items-center">
        <li>
          <h3 user-select="none" class="text-dark lighten-30 logo-font text-shadow selectable-none">
            Soups Up!
          </h3>
        </li>
        <li>
          <button class="btn mdi mdi-filter-menu-outline mdi-36px text-dark lighten-30 centered"></button>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.logo-font {
  font-family: 'Dancing Script', cursive;
  font-size: 36px;
}
.position-relative{
  position: relative;
}
.centered{
  /* position: absolute;
  position: 50% 50%; */
  margin-left: 36vw;
}
</style>
