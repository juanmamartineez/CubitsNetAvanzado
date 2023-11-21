<script setup lang="ts">
  import { ref, onMounted, computed } from 'vue';
  import Card from 'primevue/card'  
  import DataTable from 'primevue/datatable'
  import Column from 'primevue/column'
  
  let userList = ref([]);

  let userListCount = computed(() => {
    return userList.value.length
  });

  const getUserList = async () => {
    const response = await fetch('http://localhost:5000/api/users')
    const data = await response.json()
    userList.value = data.usersList
  }

  onMounted(async () => {
    await getUserList();
  })
</script>

<template>
  <div class="grid">
    <div class="col-12">
      <Card>
      <template #title> Usuarios </template>
      <template #content>
          <p class="m-0">
              Detalle de {{ userListCount }} usuarios
          </p>
      </template>
    </Card>
    </div>
  </div>
  <div class="mb-3"></div>
  <div class="grid">
    <div class="col-12">
      <DataTable :value="userList">
        <Column field="name" header="Nombre"></Column>
        <Column field="lastName" header="Apellido"></Column>
        <Column field="dni" header="DNI"></Column>
        <Column field="age" header="Edad"></Column>
      </DataTable>
    </div>
  </div>
</template>