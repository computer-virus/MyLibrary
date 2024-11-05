A personal library that contains all of Computer Virus' custom classes and methods. Most of which serve as shortcuts for basic program processes.

I plan to update it frequently frequently, so if you're interested it keeping your copy of the library up to date, make sure you check the repo regularly.

To use it, you'll need to build it and add it as a reference to the project you wish to use it with.

**To Build:**
- Download the repo and run the solution using your IDE of choice. (The rest of the instructions, including the building instructions, assume you are using Visual Studio Code. If you aren't, it should still be something similar.)
- Make sure it imported properly (for now, hovering over the classes and methods to see descriptions and checking the error log should be enough) and then go to Build > Build MyLibrary on the top tool bar.
- If the build is successful, we can now check the built file. If not, I probably messed up, let me know.
- In your repo folder, there should be a bin folder. The exact address you're looking for should be something like: [Your Repo Folder Name]\MyLibrary\bin\Debug\net8.0\
- You'll know the project was built if there's a .dll file.

**Using MyLibrary In A Project:**
- Either create a new project or open an existing project that you wish to use the library.
- Go to Project > Add Project Reference
- Click on Browse
- Find the .dll file in file explorer.
- Ensure that the file is checked after you've imported it and then click OK
- At the very top of your project (Yes, even before declaring the namespace. This should be on Line 1 of your project file.), write the line: using MyLibrary;
- If you get no errors, you're good to go!

**Disclaimer:**
I wouldn't recommend using this for school projects you intend on handing in since everyone using the project will need to have the library and (most of the time) will need it to be the same version as the one you used.

Feel free to add/remove/change anything from your copy of the library to suit your needs.

Also, this isn't technically your code, so it may be counted as cheating, I'm not sure. Technically, you use libraries made by other people all the time anyway, but I personally wouldn't risk it.

However, for stuff like excercises and quickly writing shortcuts for in-class demos, go right ahead!

Finally, of course, you can also use this for personal projects. It wouldn't make sense to give the source code to you otherwise, would it?
