<script>
    const loadCommunities = () => fetch('http://localhost:1337/api/communities').then(res => res.json());
</script>

<div class="container p-6 mx-auto text-center bg-yellow-100 rounded mt-12 text-black">
    Example rendering communities from api:

    {#await loadCommunities()}
        <p>Loading communities...</p>
    {:then data}
        <ul>
            {#each data.data as community}
                <li>{community.attributes.name} - {community.attributes.description}</li>
            {/each}
        </ul>
    {:catch error}
        <p>Something went wrong: {error.message}</p>
    {/await}
</div>