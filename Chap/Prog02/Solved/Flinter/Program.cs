
Profile profile1 = new Profile(Profile.Gender.Man, 
                               Profile.EyeColor.Blue, 
                               Profile.HairColor.Black, 
                               Profile.HeightCategory.Short);
Profile profile2 = new Profile(Profile.Gender.Woman, 
                               Profile.EyeColor.Blue, 
                               Profile.HairColor.Blond, 
                               Profile.HeightCategory.Tall);
Profile profile3 = new Profile(Profile.Gender.Man, 
                               Profile.EyeColor.Green, 
                               Profile.HairColor.White, 
                               Profile.HeightCategory.Unknown);
Profile profile4 = new Profile(Profile.Gender.NonBinary,
                               Profile.EyeColor.Brown,
                               Profile.HairColor.Grey,
                               Profile.HeightCategory.Medium);

Console.WriteLine(profile1.Description);
Console.WriteLine(profile2.Description);
Console.WriteLine(profile3.Description);
Console.WriteLine(profile4.Description);
