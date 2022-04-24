# vanguard-camo-tracker-api
## About
Server-side API counterpart to [vanguard-camo-tracker](https://github.com/dialupmodem/vanguard-camo-tracker). Built with .NET and EFCore (SQLite).

## Data
This includes a default copy of a database containing all categories, weapons and challenges. The web component that accompanies this project is currently only intended for a single user and the application only updates the `Progress` Column in the 'WeaponChallenges` table.

## Weapon Images
I've templated most/all of the weapon images using a single image from an external site. As it is currently I don't have the availability to grab screen captures from the game for weapons. With that considered, if someone stumbles upon this and wishes PR updated weapon images (or otherwise has a reliable source) please feel free.
