function getInstructors() {
    
    var instructors = '{"instructors": [{"First": "Branden", "Middle": "Wayne", "Last": "Alder"}, {"First": "John", "Middle": "Dayne", "Last": "Smith"}]}'
    return JSON.parse(instructors);
}

function initializeInstructors() {
    var data = getInstructors();

    displayInstructors(data.instructors);
}

function displayInstructors(instructors) {
    var tableRows = "";
    
    for (i = 0; i < instructors.length; i++) {
        var First = instructors[i].First;
        var Middle = instructors[i].Middle;
        var Last = instructors[i].Last;
        tableRows += "<tr><td>" + First + "</td><td>" + Middle + "</td><td>" + Last;
    }
    document.getElementById("instructorTable").innerHTML = tableRows ;
}