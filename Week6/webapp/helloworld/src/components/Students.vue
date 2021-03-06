<template>
    <div>
        <h2 class='section-heading'>Students</h2>
        <table>
            <thead>
                <tr>
                    <th>Student ID</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="student in students" v-bind:key="student">
                    <td>{{ student.studentId }}</td>
                    <td>{{ student.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        name: 'Students',
        mounted(){
            this.students = getStudents();
        },
        data(){
            return{
                students:[]
            }
        }
    }

    function getStudents() {
        return JSON.parse(students);
    }

    var students = '[{"studentId": "918656545", "email": "jane.smith@oit.edu"}, {"studentId": "918898787", "email": "matt.jones@oit.edu"}]';

</script>

<style scoped>
    table, th, td {
        padding: 10px;
        border: 5px solid black; 
        border-collapse: collapse;
        text-align: center;
    }
    table{
        width:100%;
    }
</style>