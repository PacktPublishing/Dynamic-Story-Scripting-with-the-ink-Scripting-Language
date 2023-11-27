


# Dynamic Story Scripting with the ink Scripting Language

<a href="https://www.packtpub.com/product/hands-on-dynamic-story-scripting-with-ink/9781801819329?utm_source=github&utm_medium=repository&utm_campaign="><img src="https://static.packt-cdn.com/products/9781801819329/cover/smaller" alt="" height="256px" align="right"></a>

This is the code repository for [Dynamic Story Scripting with the ink Scripting Language](https://www.packtpub.com/product/hands-on-dynamic-story-scripting-with-ink/9781801819329?utm_source=github&utm_medium=repository&utm_campaign=), published by Packt.

**Create dialogue and procedural storytelling systems for Unity projects**

## What is this book about?
ink is a narrative scripting language designed for use with game engines such as Unity through a plugin that provides an application programming interface (API) to help you to move between the branches of a story and access the values within it.
Hands-On Dynamic Story Scripting with the ink Scripting Language begins by showing you how ink understands stories and how to write some simple branching projects. You'll then move on to advanced usage with looping structures, discovering how to use variables to set up dynamic events in a story and defining simple rules to create complex narratives for use with larger Unity projects. As you advance, you'll learn how the Unity plugin allows access to a running story through its API and explore the ways in which this can be used to move data in and out of an ink story to adapt to different interactions and forms of user input. You'll also work with three specific use cases of ink with Unity by writing a dialogue system and creating quest structures and other branching narrative patterns.

This book covers the following exciting features:
* Learn how to translate stories into ink code to create interactive projects
* Gain valuable insight into the ink story API to create engaging stories using the Unity plugin
* Develop drop-in solutions to common narrative problems for Unity projects

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1801819327) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>

## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
public class InkLoader : MonoBehaviour{
   public TextAsset InkJSONAsset;
   
   // Start is called before the first frame update
   void Start()
   {
           Story exampleStory = new Story(InkJSONAsset.text);
   }
}
```

**Following is what you need for this book:**
This book is for Unity developers looking for a solution for narrative-driven projects and authors who want to create interactive story projects in Unity. Basic knowledge of Unity game engine development and related concepts is needed to get the most out of this book.

With the following software and hardware list you can run all code files present in the book (Chapter 1-12).
### Software and Hardware List
| Chapter | Software required | OS required |
| -------- | ------------------------------------ | ----------------------------------- |
| 1 | Ink 1.0 | Windows, Mac OS X, and Linux (Any) |
| 1 | Unity 2021.1 | Windows, Mac OS X, and Linux (Any) |


We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781801819329_ColorImages.pdf).

### Related products
* Hands-On Unity 2021 Game Development - Second Edition [[Packt]](https://www.packtpub.com/product/hands-on-unity-2021-game-development-second-edition/9781801071482?utm_source=github&utm_medium=repository&utm_campaign=) [[Amazon]](https://www.amazon.com/dp/1801071489)

* Game Development Patterns with Unity 2021 - Second Edition [[Packt]](https://www.packtpub.com/product/game-development-patterns-with-unity-2021-second-edition/9781800200814?utm_source=github&utm_medium=repository&utm_campaign=) [[Amazon]](https://www.amazon.com/dp/1800200811)


## Get to Know the Author
**Daniel Cox**
is a PhD student in Texts and Technology program and a visiting instructor in the Games and Interactive Media department at the University of Central Florida with a decade of experience creating online learning materials across interactive fiction tools such as Twine, Bitsy, and ink. He previously helped create and served as the managing editor of the Twine Cookbook for 4 years. He currently teaches game design as a full-time instructor and volunteers with the Interactive Fiction Technology Foundation

### Download a free PDF

 <i>If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost.<br>Simply click on the link to claim your free PDF.</i>
<p align="center"> <a href="https://packt.link/free-ebook/9781801819329">https://packt.link/free-ebook/9781801819329 </a> </p>

## Errata

* Misspelling in Chapter 7: Line 53 of `InkStory.c`s should be "DestroyButtonChildren();". [This has been fixed in the online example code.](https://github.com/PacktPublishing/Dynamic-Story-Scripting-with-the-ink-Scripting-Language/commit/4008d6aba3737ccc41aeab78685e9721df43c1be)
