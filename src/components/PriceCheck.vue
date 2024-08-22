<template>
    <div>
        <div class="row justify-content-center">
            <div class="col-4">
                <h1>Price Check</h1>
                <p>Check the prices here!</p>
                <br>

                <label for="exampleInputEmail1" class="form-label">Vehicule base price</label>
                <input v-model.number="vehiculeValue" type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                <div id="emailHelp" class="form-text">Please enter the exact base price.</div>

                <br>

                <select v-model.number="vehiculeType" class="form-select" aria-label="Default select example">
                    <option selected>Select vehicule type</option>
                    <option value="1">Common</option>
                    <option value="2">Luxury</option>
                </select>

                <br>

                <span>{{ firstFee }}</span>
            </div>
        </div>
    </div>
  </template>
  
<script lang="ts">
    import { defineComponent, ref, watch } from 'vue';
    import axios, { AxiosError } from 'axios';

    export default defineComponent({
        name: "PriceCheck",
        setup() {
            const vehiculeValue = ref<number>(0);
            const vehiculeType = ref<number>(0);
            const firstFee = ref<string | null>(null);

            watch([vehiculeValue, vehiculeType], async () => {
                await calculateFinalPrice();
            });

            async function calculateFinalPrice() {
            try {
                const requestData = {
                    VehiculeBasePrice: vehiculeValue.value,
                    VehiculeType: vehiculeType.value,
                };
                console.log('Sending request data:', requestData); // Debugging lineOua

                const response = await axios.post('http://localhost:5242/api/sample', requestData);
                firstFee.value = response.data;
            } catch (error) {
                // Handle different error types
                if (axios.isAxiosError(error)) {
                // Handle Axios errors
                const axiosError = error as AxiosError;
                console.error('Response error data:', axiosError.response?.data);
                console.error('Response error status:', axiosError.response?.status);
                console.error('Response error headers:', axiosError.response?.headers);
                } else if (error instanceof Error) {
                // Handle generic errors
                console.error('Error message:', error.message);
                } else {
                // Handle unexpected errors
                console.error('Unexpected error:', error);
                }
            }
            }

            // Initial calculation when the component is mounted
            calculateFinalPrice();

            return {
                vehiculeValue,
                vehiculeType,
                firstFee,
            };
        },
    })
</script>