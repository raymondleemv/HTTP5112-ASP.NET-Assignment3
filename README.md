# Humber College - Web Development Program - HTTP5112 - ASP.NET - Assignment 3

This repo connects to the school database which contains tables for teachers, students, classe, etc. The [Controller](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/tree/master/HTTP5112-ASP.NET-Assignment3/Controllers) folder contains different controller files to retrieve information from the database.

## Minimum Viable Product (MVP)

### User can view list of teachers

**GET** `http://localhost/Teacher/List`<br/>
Returns a list of teachers. <br/>
This is handled in the [TeacherController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/TeacherController.cs).<br/>
Please refer to the documentation in the file for more details.

### User can view a specific teacher based on the teacher id

**GET** `http://localhost/Teacher/Show/{id}`<br/>
Returns a specifc teacher based on {id} which represents the teacher id.<br/>
This is handled in the [TeacherController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/TeacherController.cs).<br/>
Please refer to the documentation in the file for more details.

### User can search for teachers in the search bar

![Highlighting the search bar location in the webpage](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Readme%20Images/Search%20bar.png)

### User can view list of classes

**GET** `http://localhost/Class/List`<br/>
Returns a list of classes. <br/>
This is handled in the [ClassController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/ClassController.cs).<br/>
Please refer to the documentation in the file for more details.

### User can view a specific class based on the class id

**GET** `http://localhost/Class/Show/{id}`<br/>
Returns a specifc class based on {id} which represents the class id.<br/>
This is handled in the [ClassController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/ClassController.cs).<br/>
Please refer to the documentation in the file for more details.

### User can view list of students

**GET** `http://localhost/Student/List`<br/>
Returns a list of students. <br/>
This is handled in the [StudentController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/StudentController.cs).<br/>
Please refer to the documentation in the file for more details.

### User can view a specific student based on the student id

**GET** `http://localhost/Student/Show/{id}`<br/>
Returns a specifc student based on {id} which represents the student id.<br/>
This is handled in the [StudentController.cs](https://github.com/raymondleemv/HTTP5112-ASP.NET-Assignment3/blob/master/HTTP5112-ASP.NET-Assignment3/Controllers/StudentController.cs).<br/>
Please refer to the documentation in the file for more details.
