using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CLCMilestone.Models
{
    public class GameModel
    {
        public dynamic _id { get; set; }
        [Required]
        [Range(4, 20, ErrorMessage = "The size range must be from 4 to 20")]
        public int size { get; set; }
        [Required]
        [Range(0, 20, ErrorMessage = "The difficulty range must be from 0 to 20")]
        public int difficulty { get; set; }
        public CellModel[][] grid { get; set; }
        public bool gameOver { get; set; }

        public GameModel(int size, int difficulty, CellModel[][] grid, bool gameOver)
        {
            this.size = size;
            this.difficulty = difficulty;
            this.grid = grid;
            this.gameOver = gameOver;
        }
    }
}
