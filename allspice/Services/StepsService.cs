using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _stepsRepo;

    public StepsService(StepsRepository stepsRepo)
    {
      _stepsRepo = stepsRepo;
    }

    internal List<Step> GetRecipeSteps(int recipeId)
    {
      List<Step> steps = _stepsRepo.GetRecipeSteps(recipeId);
      return steps;
    }

    internal Step GetStepById(int id)
    {
      Step step = _stepsRepo.GetStepById(id);
      if(step == null){
        throw new Exception("Bad step Id");
      }
      return step;
    }

    internal Step CreateStep(Step newStep)
    {
      return _stepsRepo.CreateStep(newStep);
    }

    internal Step EditStep(Step updatedStep)
    {
      Step original = GetStepById(updatedStep.Id);
      original.Position = updatedStep.Position ?? original.Position;
      original.Body = updatedStep.Body ?? original.Body;
      return _stepsRepo.EditStep(original);
    }

    internal string DeleteStep(Account userInfo, int id)
    {
      Step step = GetStepById(id);
      if(step.CreatorId != userInfo.Id) {
        throw new Exception("You do not have permission to delete this step");
      }
      _stepsRepo.DeleteStep(step.Id);
      return $"Step #{step.Position} has been deleted";
    }
  }
}