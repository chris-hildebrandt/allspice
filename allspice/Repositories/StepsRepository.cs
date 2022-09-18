using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class StepsRepository
  {
    private readonly IDbConnection _db;
    public StepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Step> GetRecipeSteps(int recipeId)
    {
      string sql = @"SELECT * FROM steps s WHERE s.recipeId = @recipeId;";
      List<Step> steps =_db.Query<Step>(sql, new {recipeId}).ToList();
      return steps;
    }

    internal Step GetStepById(int id)
    {
      string sql = @"SELECT * FROM steps s WHERE s.id = @id";
      Step step = _db.Query<Step>(sql, new {id}).FirstOrDefault();
      return step;
    }

    internal Step CreateStep(Step newStep)
    {
      string sql = @"INSERT INTO steps
      (position, body, recipeId, creatorId)
      VALUES
      (@position, @body, @recipeId, @creatorId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newStep);
      newStep.Id = id;
      return newStep;
    }

    internal Step EditStep(Step original)
    {
      string sql = @"UPDATE steps SET 
      position = @position
      body = @body";
      int rowsAffected = _db.Execute(sql, original);
      if(rowsAffected == 0){
        throw new Exception("unable to edit step");
      }
      return original;
    }

    internal void DeleteStep(int id)
    {
      string sql = @"DELETE FROM steps WHERE id = @id";
      _db.Execute(sql, new{id});
    }
  }
}