<template>
    <div>
        <h2>Instructor Table</h2>
        <table style="width:100%">
            <tr align="left">
                <th> First Name </th>
                <th> Middle Name </th>
                <th> Last Name </th>
            </tr>
            <tbody id="instructorTable">
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
  name: 'Instructors',
}
</script>

<style scoped>
    table, th, td {
        padding: 10px;
        border: 5px solid black; 
        border-collapse: collapse;
    }
</style>