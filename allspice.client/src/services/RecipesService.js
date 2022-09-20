import { AppState } from "../AppState.js"
import { api } from "./AxiosService.js";

class RecipesService {
 async getAllRecipes(){
  AppState.recipes = []
  // refresh appstate?
  const res = await api.get('api/recipes')
  console.log(res);
  AppState.recipes = res.data
 }
}
export const recipesService = new RecipesService()