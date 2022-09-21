import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js";

class RecipesService {
 async getAllRecipes(){
  // AppState.recipes = []
  // refresh AppState?
  const res = await api.get('api/recipes')
  console.log(res);
  AppState.recipes = res.data
  // AppState.recipes.forEach(r=> this.getRecipeTags(r.id))
 }

 async getRecipeTags(recipeId){
  const res = await api.get(`api/${recipeId}/recipe-tags`)
  console.log(res.data);
  // AppState.tags = res.data
 }
}
export const recipesService = new RecipesService()