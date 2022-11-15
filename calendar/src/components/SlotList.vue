<template>
    <section class="slot-table">
        <Slot v-for="slot in 22"
            :key="slot"
            :slot="slot"
            :class="{busy: busySlots.includes(slot)}"
            @click:toggle="toggleBusy(slot)"
        /> 
    </section>
    {{ busySlots }}
</template>

<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios'
import Slot from '@/components/Slot.vue'

const busySlots = ref<number[]>([]);
const date = window.location.pathname.split('/')[2]+'T00:00:00+00:00';


const getAllSlots = async (date: string) => {
    const response = await axios.get(`https://localhost:7299/ReservedSlot/${date}`);

    for (let p in response.data) {
        if (!busySlots.value.includes(response.data[p].index)){
            busySlots.value.push(response.data[p].index);
        }
    }
};
getAllSlots(date);

const toggleBusy = async (slot: number) => {
    if (busySlots.value.includes(slot)) {
        deleteSlot(slot, date);
    } else {
        reserveSlot(slot, date);
    }
};

const deleteSlot = async (slot: number, date: string) => {
    await axios.delete(`https://localhost:7299/ReservedSlot/search/${slot}&${date}`);
    busySlots.value = busySlots.value.filter(num => slot != num);
}

const reserveSlot = async (slot: number, date: string) => {
    await axios.post(`https://localhost:7299/ReservedSlot/`, {date: `${date}`, index: `${slot}`, description: ''});
    await getAllSlots(date);
}

</script>

<style scoped>
.slot-table {
    box-sizing: border-box;
    display: flex;
    flex-wrap: wrap;
    gap: 5px;
    width: 400px;
}
.busy {
    background-color: lightseagreen;
    color: white;
}
</style>