<template>
    <div>
        <h2 class='section-heading'>Instructors</h2>
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="instructor in instructors" v-bind:key="instructor">
                    <td>{{ instructor.firstName }}</td>
                    <td>{{ instructor.lastName }}</td>
                    <td>{{ instructor.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        name: 'Instructors',
        mounted(){
            this.instructors = getInstructors();
        },
        data(){
            return{
                instructors:[]
            }
        }
    }

    function getInstructors(){
        return JSON.parse(instructors);
    }

    var instructors = '[{"firstName": "Terry", "lastName": "Cruz", "email": "terry.cruz@oit.edu"}, {"firstName": "Bill", "lastName": "Benson", "email": "bill.benson2@oit.edu"}]';

</script>

<style scoped>
    table, th, td {
        padding: 10px;
        border: 5px solid black; 
        border-collapse: collapse;
        text-align: center;
    }
    table{
        width:100%
    }
</style>