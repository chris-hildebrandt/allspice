<template>
  <RecipeForm/>
  <div v-if="recipes.length" class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row p-3" v-for="r in recipes" :key="r.id">
      <RecipeCard :recipe="r"/>
      <!--           ^ name of prop passed down in the component-->
    </div>
  </div>
  <button id="create-recipe-btn" data-bs-target="#recipe-form" data-bs-toggle="modal" class="btn mdi mdi-plus-outline mdi-36px text-dark lighten-30" @click=""></button>
</template>


<script>
import { recipesService } from "../services/RecipesService.js"
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { onMounted } from "vue";
import { computed } from "@vue/reactivity";
import RecipeCard from "../components/RecipeCard.vue";
import RecipeForm from "../components/RecipeForm.vue";


export default {
  name: "Home",
  setup() {
    // const filterTerm = ref('')
    onMounted(() => {
      getAllRecipes();
    });
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        logger.error("[getting recipes]", error);
        Pop.error(error);
      }
    }
    return {
      // filterTerm,
      recipes: computed(() => AppState.recipes)
      // .filter(r=> filterTerm.value ? r.tag == filterTerm.value : true )),
    };
  },
  components: { RecipeCard, RecipeForm }
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
