using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace PetNameGenerator.Controllers
{
	public class PetNameController : ControllerBase
	{

		private readonly string[] dogNames = new string[] { "Buddy", "Charlie", "Luna", "Cooper", "Bailey" };
		private readonly string[] catNames= new string[]  { "Whiskers", "Simba", "Shadow", "Lily", "Oreo" };
		private readonly string[] birdNames = new string[] { "Tweety", "Rio", "Sunny", "Sky", "Chirpy" };

		private readonly string[] dogLastNames = new string[] { "Barker", "Pawson", "Woofington", "Furry", "Sniffer" };
		private readonly string[] catLastNames = new string[] { "Whiskerton", "Meowington", "Purrkins", "Fluffington", "Scratchley" };
		private readonly string[] birdLastNames = new string[] { "Featherstone", "Wingman", "Beakley", "Chirpson", "Skyler" };

		[HttpPost("generate")]
		public IActionResult Post(string animalType, bool twoPart)
		{
			Random rndFirst = new Random();
			Random rndLast = new Random();
			string petName;

			switch (animalType)
			{
				case "dog":
					petName = dogNames[rndFirst.Next(dogNames.Length)];
					break;
				case "cat":
					petName = catNames[rndFirst.Next(catNames.Length)];
					break;
				case "bird":
					petName = birdNames[rndFirst.Next(birdNames.Length)];
					break;
				default:
					return BadRequest("Invalid Animal Type");

			}

			if (twoPart)
			{
				switch (animalType)
				{
					case "dog":
						petName += " " + dogLastNames[rndLast.Next(dogNames.Length)];
						break;
					case "cat":
						petName += " " + catLastNames[rndLast.Next(dogNames.Length)];
						break;
					case "bird":
						petName += " " + birdLastNames[rndLast.Next(dogNames.Length)];
						break;
					default:
						break;

				}
			}
			

			return Ok(new { petName=petName });
		}
	}
}
