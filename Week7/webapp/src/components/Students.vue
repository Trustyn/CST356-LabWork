<template>
    <div>
        <div v-if='operation == "list"'>
            <h2 class='section-heading'>Students</h2>
                <table>
                    <thead>
                        <tr>
                            <th>Student ID</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                <tbody>
                    <tr v-for="student in students" :key="student.studentId">
                        <td>{{ student.studentID }}</td>
                        <td>{{ student.email }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
    import Vue from 'vue';
    export default {
        name: 'Students',
        
        data () {
            return {
                students: [],
                operation: 'list',
                studentID: undefined,
                email_address: undefined,
                studentUpdateId: undefined,
                apiServer: process.env.VUE_APP_API_SERVER
            }
        },
        methods: {
            getStudents: function() {
                let url = `http://${this.apiServer}/api/student`;
                Vue.axios.get(url).then(
                    (response) => {
                        this.students = response.data;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            getStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}`;
                Vue.axios.get(url).then(
                    (response) => {
                        this.name = response.data.name;
                        this.price = response.data.price;
                        this.count = response.data.count;
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayAddStudent: function() {
                this.name = undefined;
                this.price = undefined;
                this.count = undefined;
                this.operation = 'add';
            },
            addStudent: function() {
                let url = `http://${this.apiServer}/api/student`;
                Vue.axios.post(url, {
                    name: this.name,
                    price: parseFloat(this.price),
                    count: parseInt(this.count)
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            displayStudentDetails: function(studentId) {
                this.getStudent(studentId);
                this.operation = 'detail';
            },
            displayUpdateStudent: function(studentId) {
                this.studentUpdateId = studentId;
                this.getStudent(studentId);
                this.operation = 'update';
            },
            updateStudent: function() {
                let url = `http://${this.apiServer}/api/student/${this.studentUpdateId}`;
                Vue.axios.put(url, {
                    name: this.name,
                    price: parseFloat(this.price),
                    count: parseInt(this.count)
                }).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            deleteStudent: function(studentId) {
                let url = `http://${this.apiServer}/api/student/${studentId}`;
                Vue.axios.delete(url).then(
                    () => {
                        this.getStudents();
                        this.operation = 'list';
                    },
                    (error) => {
                        console.log(error)
                    }
                );
            },
            cancel: function() {
                this.operation = 'list';
            }
        },
        mounted() {
            this.getStudents();
            this.operation = 'list';
        }
    }
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