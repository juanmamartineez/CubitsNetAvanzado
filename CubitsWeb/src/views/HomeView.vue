<script setup lang="ts">
  import Card from 'primevue/card'  
  import Button from 'primevue/button'
</script>

<template>
  <div class="row">
    <div class="col-12">
      <div class="card mt-1 text-center">
        <Card>
          <template #title> Usuarios </template>
          <template #content>
            <div class="card mt-1 text-center">
              <router-link to="/users" custom v-slot="{ navigate }">
                <Button label="Ver" severity="success" @click="navigate" role="link"/>
              </router-link>
            </div>
          </template>
        </Card>
      </div>
    </div>
  </div>
</template>