<template>
  <!-- card opens modal with ingredients and steps -->
  <div v-if="recipe.tags.includes('Sandwich')">
    <div class="card p-5 bg-white rounded elevation-3">
      <img
        src="https://static.wikia.nocookie.net/spongebob/images/b/b9/Nasty_Patty_061.png/revision/latest?cb=20200805135150"
        alt="">
      <p>{{}}</p>
    </div>
  </div>
  <div v-else>
    <div class="col-6 col-md-4">
      <div class="card bg-light text-dark elevation-3">
        <img class="card-img" :src="recipe.picture" alt="Card image">
        <div class="card-img-overlay">
          <h5 class="card-title">Card title</h5>
          <p class="card-text"></p>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import { onMounted } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: { recipe: { type: Object, required: true } },
  setup() {

    // async function getRecipeTags() {
    //   try {
    //     console.log("props", props.recipe);
    //     await recipesService.getRecipeTags(props.recipe.id)
    //   } catch (error) {
    //     Pop.error(error);
    //   }
    // }
    onMounted(() => {
      // getRecipeTags();
    });
    return {

    }
  }
}
</script>

<style lang="scss" scoped>

</style>