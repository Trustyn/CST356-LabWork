<template>
    <div>
        <h2>Student Table</h2>
        <table style="width:100%">
            <tr align="left">
                <th> Student ID </th>
                <th> Email </th>
            </tr>
            <tbody id="studentTable">

            </tbody>
        </table>
    </div>
</template>

<script>
export default {
  name: 'Students',
}
</script>

<style scoped>
    table, th, td {
        padding: 10px;
        border: 5px solid black; 
        border-collapse: collapse;
    }
</style>