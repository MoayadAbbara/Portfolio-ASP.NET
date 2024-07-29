$(document).ready(function () {
    // Handle EditSkill button click
    $('.EditSkill').on('click', function () {
        var skillId = $(this).data('id');

        // Make an AJAX call to get the skill details and populate the form fields
        $.ajax({
            url: "/Skill/GetSkillDetails",
            type: 'GET',
            data: { id: skillId },
            success: function (data) {
                $('#SkillId').val(data.id);
                $('#SkillName').val(data.name);
                $('#SkillRatio').val(data.ratio);
            }
        });
    });

    // Handle EditFact button click
    $('.EditFact').on('click', function () {
        var factId = $(this).data('id');

        // Make an AJAX call to get the fact details and populate the form fields
        $.ajax({
            url: "/Fact/GetFactDetails",
            type: 'GET',
            data: { id: factId },
            success: function (data) {
                $('#editFactID').val(data.id);
                $('#editFactName').val(data.fact);
                $('#editFactNum').val(data.num);
                $('#editFactClass').val(data.iconClassName);
            }
        });
    });




    // Handle EditProject button click
    $('.EditProject').on('click', function () {
        var ProjectId = $(this).data('id');

        // Make an AJAX call to get the fact details and populate the form fields
        $.ajax({
            url: "/Project/GetProjectDetails",
            type: 'GET',
            data: { id: ProjectId },
            success: function (data) {
                $('#ProjectId').val(data.id);
                $('#ProjectName').val(data.title);
                $('#ProjectType').val(data.typeID);
                $('#ProjectLink').val(data.link);

                // Parse the date and adjust for timezone
                var date = new Date(data.projectDate);
                var userTimezoneOffset = date.getTimezoneOffset() * 60000;
                var correctedDate = new Date(date.getTime() - userTimezoneOffset);
                var formattedDate = correctedDate.toISOString().split('T')[0];
                $('#ProjectDate').val(formattedDate);

                $('#ProjectDescription').val(data.description);


                // Handle the list of image links
                var imagesContainer = $('#ImagesContainer');
                imagesContainer.empty(); 
                data.images.forEach(function (link) {
                    var imgElement = $('<img>', {
                        src: link,
                        class: 'img-thumbnail',
                        style: 'max-width: 100px; margin: 5px;'
                    });
                    imagesContainer.append(imgElement);
                });
            }
        });
    });




    $('.addNewImage').on('click', function () {
        var projectId = $('#ProjectId').val();
        var ImageLink = $('#ImageLink').val()


        // Make an AJAX call to get the fact details and populate the form fields
        $.ajax({
            url: "/Project/AddNewImage",
            type: 'POST',
            data: {
                ProjectID: projectId,
                Link: ImageLink
            },
            success: function (response) {
                    window.location.href = response.redirectUrl;
            },
        });
    });


});
