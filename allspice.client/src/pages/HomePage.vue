<template>
  <RecipeForm/>
  <div v-if="recipes.length" class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row p-3" v-for="r in recipes" :key="r.id">
      <RecipeCard :recipe="r"/>
      <!--           ^ name of prop passed down in the component-->
    </div>
  </div>
  <button type="button" class="btn mdi mdi-plus-outline mdi-36px text-dark lighten-30" data-bs-toggle="modal" data-bs-target="#create-recipe" id="create-recipe-btn"></button>

  <Modal>
    <div class="modal fade" id="create-recipe" tabindex="-1" aria-labelledby="create-recipeLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="create-recipeLabel">What is the name of your soup recipe?</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <input type="text">
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <!-- router push to details page is simpler than a double modal loop -->
            <button  data-bs-target="#recipe-form" data-bs-toggle="modal" class="btn" >Create Recipe</button>
          </div>
        </div>
      </div>
    </div>
  </Modal>

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
      recipes: computed(() => AppState.recipes),
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
