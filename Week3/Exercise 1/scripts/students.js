var students = '{"students": [{"StudentID": "918555555", "Email": steve.joe@oit.edu}, {"StudentID": "918666666", "Email": karen.willis@oit.edu}]}'

return JSON.parse(students);

function initializeStudents() {
    var data = getStudents();

    displayStudents(data.students);
}

function displayStudents(students) {

    var tableRows = "";
    for (i = 0; i < students.length; i++) {
        var StudentID = students[i].StudentID;
        var Email = students[i].Email;
        tableRows += "<tr><td>" + StudentID + "</td><td>" + Email + "</td></tr>";
    }
    document.getElementById("studentTable").innerHTML = tableRows ;
}