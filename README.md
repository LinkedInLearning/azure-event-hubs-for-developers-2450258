# Azure Event Hubs for Developers
This is the repository for the LinkedIn Learning course Azure Event Hubs for Developers. The full course is available from [LinkedIn Learning][lil-course-url].

![Azure Event Hubs for Developers][lil-thumbnail-url] 

As modern applications become more decentralized and developers need to create solutions for receiving and processing events generated from multiple sources, building data ingestion pipelines that are simple, trusted, and scalable has never been more important. In this course, Nertil Poci teached you how to build data processing solutions with Azure Event Hubs. Nertil goes over provisioning event hubs, sending events, and creating event processors to read the messages coming into your hub. If you’re looking to use Azure Event Hubs to ingest data and create actionable insights, check out this course.

## Instructions
This repository has branches for each of the videos in the course. You can use the branch pop up menu in github to switch to a specific branch and take a look at the course at that stage, or you can add `/tree/BRANCH_NAME` to the URL to go to the branch you want to access.

## Branches
The branches are structured to correspond to the videos in the course. The naming convention is `CHAPTER#_MOVIE#`. As an example, the branch named `02_03` corresponds to the second chapter and the third video in that chapter. 
Some branches will have a beginning and an end state. These are marked with the letters `b` for "beginning" and `e` for "end". The `b` branch contains the code as it is at the beginning of the movie. The `e` branch contains the code as it is at the end of the movie. The `main` branch holds the final state of the code when in the course.

When switching from one exercise files branch to the next after making changes to the files, you may get a message like this:

    error: Your local changes to the following files would be overwritten by checkout:        [files]
    Please commit your changes or stash them before you switch branches.
    Aborting

To resolve this issue:
	
    Add changes to git using this command: git add .
	Commit changes using this command: git commit -m "some message"

## Installing
1. To use these exercise files, you must have the following installed:
	- Visual Studio 2022
	- .net 6
2. Clone this repository into your local machine using the terminal (Mac), CMD (Windows), or a GUI tool like SourceTree.



### Instructor

Nertil Poci 
                            
Software Developer

                            

Check out my other courses on [LinkedIn Learning](https://www.linkedin.com/learning/instructors/nertil-poci).

[lil-course-url]: https://www.linkedin.com/learning/azure-event-hubs-for-developers
[lil-thumbnail-url]: https://cdn.lynda.com/course/2450258/2450258-1649355313972-16x9.jpg
