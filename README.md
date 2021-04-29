# OneNews

Links to view-https://miro.com/app/board/o9J_lJfUd0U=/


What you can do:
OneNews app allows news organizations to add news stories. The app has user roles to prevent  certain users from accessing content.
Publishers roles can create new News articles and Access all controller endpoints in category and writer. publishers can only edit, update, and delete only their personal published stories.
Admin role can create and unassigned  roles and has all access to stories, category and writer endpoints.
Users can view all articles by category or writer.
Admins can assign role to any user as well as remove a role



How to use:
To use the OneNews application you cant start by using an app like Postman to create an account in order to use the app and view news stories of their choice. A user will be able to select a category that they would like to view, they will also be able to view all stories, writers and get story by writer.
We have seeded the role of "Publisher" and "Admin" into the database, and created endpoints that allow an Admin to assign "Publisher" role to any registered user.

The admin's endpoints are:

api/Account/admin/GetAllUsers (see a list of all users)

api/Account/admin/AssignRole (assign a role to a user)

api/Account/admin/UnassignRole (unassign a role to a user)

We have also seeded a user account with Admin role:

Email: administrator@OneNews.com - seeded as Admin

Password: 1NewsAdministrator!

An admin of the application after being created can use postman to create a writer, as well as create a story that will have a

category assigned. The admin can then attach a writer to that story. The admin can delete a story, writer and category by using

Postman and selecting the delete action and inputting the writer id, category id or story id.

The admin can edit each by choosing put and editing as necessary . If the admin is not sure of the correct properties, after running the application the admin can view the API and view each end point along with the properties attached to enter in postman when creating, editing or deleting.


Why is this useful:
The OneNews app is useful for those that want all of their news in one place. Its also useful for users who only want to view specific articles by specific writers. Rather it is the NYT, CNN, FOX or MSNBC those publishers can share their content on the application for users to view in one place instead of having to go to 4 different sites.

