<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">

  </div>
  <button id="create-recipe-btn" class="btn mdi mdi-plus-outline mdi-36px text-dark lighten-30"></button>
</template>


<script>
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { onMounted } from "vue";
import { computed } from "@vue/reactivity";


export default {
  name: 'Home',

  setup() {
    // const filterTerm = ref('')

    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      } catch (error) {
        logger.error('[getting recipes]', error);
        Pop.error(error);
      }
    }

    onMounted(()=>{
      getAllRecipes();
    });
    return {
      // filterTerm,
      // recipes: computed(()=> AppState.recipes.filter(r=> filterTerm.value ? r.tag == filterTerm.value : true )),
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
}

#create-recipe-btn {
  position: fixed;
  left: 93vw;
  top: 88vh;
}
</style>
