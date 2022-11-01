<template>
  <Modal>
    <div class="modal fade" id="recipe-form" tabindex="-1" data-bs-keyboard="false" role="dialog"
      aria-labelledby="modalTitleId" aria-hidden="true">
      <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-xl" role="document">
        <div class="modal-content">
          <div class="modal-header">

            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">

            <!-- SECTION title/subtitle/picture/description -->
            <!-- ask for recipe name first and do a create recipe before opening this modal. -->
            <div class="mb-3">
              <label for="title" name="title" class="form-label">Recipe Title</label>
              <input v-model="editable.title" type="text" class="form-control" id="title" placeholder="Recipe Title"
                required maxlength="100">
            </div>
            <div class="row">
              <div class="mb-3 col-12 col-md-6">
                <label for="subtitle" name="subtitle" class="form-label">Subtitle</label>
                <input v-model="editable.subtitle" type="text" class="form-control" id="subtitle" placeholder="optional"
                  maxlength="100">
              </div>
              <div class="mb-3 col-12 col-md-6">
                <label for="picture" name="picture" class="form-label">Picture</label>
                <input v-model="editable.picture" type="url" class="form-control" id="picture"
                  placeholder="image or url" required maxlength="255">
              </div>
            </div>
            <div class="mb-3">
              <label for="exampleFormControlTextarea1" class="form-label">Example textarea</label>
              <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
            </div>

            <!-- SECTION ingredients/steps -->
            <!-- <div class="isiaFormRepeater repeat-section" id="ingredients" data-field-id="ingredients_field_id"
              data-items-index-array="[1]">
              <div class="repeat-items input-group">
                <div class="repeat-item" data-field-index="1">
                  <input type="text" class="form-control repeat-el" placeholder="Ingredient"
              id="ingredients_field_id[test_sub1][1]" name="ingredients_field_id[test_sub1][1]"
              aria-label="add ingredients or instructions">
                </div>
              </div>
            </div> -->

            <div class="row">
              <form class="col-12 col-md-6">
                <div v-for="i in editable.ingredients" :key="i.id">
                  <input type="text" class="form-control" placeholder="Ingredient" id="ingredient" name="ingredient"
                    aria-label="add ingredients">
                </div>
                <input type="text" class="form-control" placeholder="Ingredient" id="ingredient" name="ingredient"
                  aria-label="add ingredients">
                <button class="btn btn-outline-secondary m-3" type="button">Add Ingredient</button>
              </form>

              <form class="col-12 col-md-6">
                <div v-for="s in editable.steps" :key="s.id">
                  <input type="text" class="form-control" placeholder="instruction" id="instruction" name="instruction"
                    aria-label="add instructions">
                </div>
                <input type="text" class="form-control" placeholder="Step #1..." id="instruction" name="instruction"
                  aria-label="add instructions">
                <button class="btn btn-outline-secondary m-3" type="button">Add Instructions</button>
              </form>
            </div>

            <!-- SECTION tags -->
            <div v-for="t in editable.tags" :key="t.id">
              <i class="text-dark lighten-40 mdi mdi-tag">{{t.tagName}}</i>
            </div>
            <form @submit.prevent="addTag">
              <div class="input-group">
                <select class="form-select" id="tag-select" aria-label="tag-select with add button">
                  <option selected>Choose Soup Categories...</option>
                  <option value="32">Sandwich</option>
                  <option value="Seasonal">Seasonal</option>
                  <option value="1">Gluten-Free</option>
                </select>
                <button class="btn btn-outline-secondary" type="submit">Add Tag</button>
              </div>
            </form>

          </div>
          <div class="modal-footer">

          </div>
        </div>
      </div>
    </div>
  </Modal>
</template>

<script>
import { ref, watchEffect } from "vue";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import $ from 'jquery'

export default {
  props: { recipeData: { type: Object, required: false, default: {} } },
  setup(props) {

    // $('#ingredients').isiaFormRepeater();
    // $('#ingredients').isiaFormRepeater({addButton:'Add Button Here', removeButton:'Remove Button Here'});

    const editable = ref({})
    watchEffect(() => {

      editable.value = props.recipeData
    })
    return {
      editable,
      async handleSubmit() {
        try {
          if (editable.value?.tags.includes("32")) {
            const yes = await Pop.confirm('You are trying to submit a soup that is tagged as a sandwich... are you sure you want other intelligent people to see this? You know you are only allowed to post soups on this app right?', 'warning')
            if (!yes) { return } else {
              const sure = await Pop.confirm('this violates the laws of physics, it probably violates national health and public safety laws, it likely violates poor unsuspecting grandmothers! Are you absolutely certain you want to unleash this evil on society? You may be liable for this later... your account information IS attached to the recipe after all...', 'danger')
              if (!sure) { return } else {
                await recipesService.createRecipe(editable.value);
                Pop.toast("Recipe Created Successfully!", 'success')
              }
            }
          }
        } catch (error) {
          Pop.error(error);
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>