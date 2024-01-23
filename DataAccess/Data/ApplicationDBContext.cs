using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    { }

    public DbSet<Contacts> ContactsList { get; set; }

    public DbSet<Courses> CoursesList { get; set; }

    public DbSet<Fees> FeesList { get; set; }

    public DbSet<ReceiptImage> ReceiptImagesList { get; set; }

    public virtual DbSet<AllContactsList> AllContactsList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OJRE535\\ATINDRADAS;Database=BMDataHub;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllContactsList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("allContactsList");

            entity.Property(e => e.AdditionalEmailAddresses)
                .HasMaxLength(500)
                .HasColumnName("additional_email_addresses");
            entity.Property(e => e.AgreedDateOfInitiationWithYourSwamiRishi).HasColumnName("agreed_date_of_initiation_with_your_swami_rishi");
            entity.Property(e => e.AkyTeacherCalculated).HasColumnName("aky_teacher_calculated");
            entity.Property(e => e.AkyTeacherCalculatedLabel).HasColumnName("aky_teacher_calculated_label");
            entity.Property(e => e.AkyTeachersCountriesUnderTheirResponsibility)
                .HasMaxLength(300)
                .HasColumnName("aky_teachers___countries_under_their__responsibility");
            entity.Property(e => e.AreYouABrahmachariBrahmachariniRadio).HasColumnName("are_you_a_brahmachari___brahmacharini___radio_");
            entity.Property(e => e.AreYouAvailableToDoSeva).HasColumnName("are_you_available_to_do_seva");
            entity.Property(e => e.AreYouInitiatedInAtmaKriyaYoga)
                .HasMaxLength(50)
                .HasColumnName("are_you_initiated_in_atma_kriya_yoga_");
            entity.Property(e => e.AtmaKriyaWhatYearWereYouInitiated).HasColumnName("atma_kriya_what_year_were_you_initiated_");
            entity.Property(e => e.AtmaKriyaYogaTeacherAlbania).HasColumnName("atma_kriya_yoga_teacher_albania");
            entity.Property(e => e.AtmaKriyaYogaTeacherArgentina).HasColumnName("atma_kriya_yoga_teacher_argentina");
            entity.Property(e => e.AtmaKriyaYogaTeacherAustralia).HasColumnName("atma_kriya_yoga_teacher_australia");
            entity.Property(e => e.AtmaKriyaYogaTeacherAustria).HasColumnName("atma_kriya_yoga_teacher_austria");
            entity.Property(e => e.AtmaKriyaYogaTeacherBelgium).HasColumnName("atma_kriya_yoga_teacher_belgium");
            entity.Property(e => e.AtmaKriyaYogaTeacherBolivia).HasColumnName("atma_kriya_yoga_teacher_bolivia");
            entity.Property(e => e.AtmaKriyaYogaTeacherBosniaAndHerzegovina).HasColumnName("atma_kriya_yoga_teacher_bosnia_and_herzegovina");
            entity.Property(e => e.AtmaKriyaYogaTeacherBrazil).HasColumnName("atma_kriya_yoga_teacher_brazil");
            entity.Property(e => e.AtmaKriyaYogaTeacherBulgaria).HasColumnName("atma_kriya_yoga_teacher_bulgaria");
            entity.Property(e => e.AtmaKriyaYogaTeacherCambodia).HasColumnName("atma_kriya_yoga_teacher_cambodia");
            entity.Property(e => e.AtmaKriyaYogaTeacherCanada).HasColumnName("atma_kriya_yoga_teacher_canada");
            entity.Property(e => e.AtmaKriyaYogaTeacherChile).HasColumnName("atma_kriya_yoga_teacher_chile");
            entity.Property(e => e.AtmaKriyaYogaTeacherChina).HasColumnName("atma_kriya_yoga_teacher_china");
            entity.Property(e => e.AtmaKriyaYogaTeacherColombia).HasColumnName("atma_kriya_yoga_teacher_colombia");
            entity.Property(e => e.AtmaKriyaYogaTeacherCoteDIvoire).HasColumnName("atma_kriya_yoga_teacher_cote_d_ivoire");
            entity.Property(e => e.AtmaKriyaYogaTeacherCroatia).HasColumnName("atma_kriya_yoga_teacher_croatia");
            entity.Property(e => e.AtmaKriyaYogaTeacherCzechRepublic).HasColumnName("atma_kriya_yoga_teacher_czech_republic");
            entity.Property(e => e.AtmaKriyaYogaTeacherDenmark).HasColumnName("atma_kriya_yoga_teacher_denmark");
            entity.Property(e => e.AtmaKriyaYogaTeacherEcuador).HasColumnName("atma_kriya_yoga_teacher_ecuador");
            entity.Property(e => e.AtmaKriyaYogaTeacherEgypt).HasColumnName("atma_kriya_yoga_teacher_egypt");
            entity.Property(e => e.AtmaKriyaYogaTeacherEstonia).HasColumnName("atma_kriya_yoga_teacher_estonia");
            entity.Property(e => e.AtmaKriyaYogaTeacherFinland).HasColumnName("atma_kriya_yoga_teacher_finland");
            entity.Property(e => e.AtmaKriyaYogaTeacherFrance).HasColumnName("atma_kriya_yoga_teacher_france");
            entity.Property(e => e.AtmaKriyaYogaTeacherGermany).HasColumnName("atma_kriya_yoga_teacher_germany");
            entity.Property(e => e.AtmaKriyaYogaTeacherGreece).HasColumnName("atma_kriya_yoga_teacher_greece");
            entity.Property(e => e.AtmaKriyaYogaTeacherHungary).HasColumnName("atma_kriya_yoga_teacher_hungary");
            entity.Property(e => e.AtmaKriyaYogaTeacherIndia).HasColumnName("atma_kriya_yoga_teacher_india");
            entity.Property(e => e.AtmaKriyaYogaTeacherIndonesia).HasColumnName("atma_kriya_yoga_teacher_indonesia");
            entity.Property(e => e.AtmaKriyaYogaTeacherIreland).HasColumnName("atma_kriya_yoga_teacher_ireland");
            entity.Property(e => e.AtmaKriyaYogaTeacherItaly).HasColumnName("atma_kriya_yoga_teacher_italy");
            entity.Property(e => e.AtmaKriyaYogaTeacherJapan).HasColumnName("atma_kriya_yoga_teacher_japan");
            entity.Property(e => e.AtmaKriyaYogaTeacherJordan).HasColumnName("atma_kriya_yoga_teacher_jordan");
            entity.Property(e => e.AtmaKriyaYogaTeacherKenya).HasColumnName("atma_kriya_yoga_teacher_kenya");
            entity.Property(e => e.AtmaKriyaYogaTeacherLatvia).HasColumnName("atma_kriya_yoga_teacher_latvia");
            entity.Property(e => e.AtmaKriyaYogaTeacherLebanon).HasColumnName("atma_kriya_yoga_teacher_lebanon");
            entity.Property(e => e.AtmaKriyaYogaTeacherLithuania).HasColumnName("atma_kriya_yoga_teacher_lithuania");
            entity.Property(e => e.AtmaKriyaYogaTeacherMacedonia).HasColumnName("atma_kriya_yoga_teacher_macedonia");
            entity.Property(e => e.AtmaKriyaYogaTeacherMadagascar).HasColumnName("atma_kriya_yoga_teacher_madagascar");
            entity.Property(e => e.AtmaKriyaYogaTeacherMalaysia).HasColumnName("atma_kriya_yoga_teacher_malaysia");
            entity.Property(e => e.AtmaKriyaYogaTeacherMauritius).HasColumnName("atma_kriya_yoga_teacher_mauritius");
            entity.Property(e => e.AtmaKriyaYogaTeacherMexico).HasColumnName("atma_kriya_yoga_teacher_mexico");
            entity.Property(e => e.AtmaKriyaYogaTeacherMontenegro).HasColumnName("atma_kriya_yoga_teacher_montenegro");
            entity.Property(e => e.AtmaKriyaYogaTeacherMozambique).HasColumnName("atma_kriya_yoga_teacher_mozambique");
            entity.Property(e => e.AtmaKriyaYogaTeacherNepal).HasColumnName("atma_kriya_yoga_teacher_nepal");
            entity.Property(e => e.AtmaKriyaYogaTeacherNetherlands).HasColumnName("atma_kriya_yoga_teacher_netherlands");
            entity.Property(e => e.AtmaKriyaYogaTeacherNewZealand).HasColumnName("atma_kriya_yoga_teacher_new_zealand");
            entity.Property(e => e.AtmaKriyaYogaTeacherNorway).HasColumnName("atma_kriya_yoga_teacher_norway");
            entity.Property(e => e.AtmaKriyaYogaTeacherPeru).HasColumnName("atma_kriya_yoga_teacher_peru");
            entity.Property(e => e.AtmaKriyaYogaTeacherPoland).HasColumnName("atma_kriya_yoga_teacher_poland");
            entity.Property(e => e.AtmaKriyaYogaTeacherPortugal).HasColumnName("atma_kriya_yoga_teacher_portugal");
            entity.Property(e => e.AtmaKriyaYogaTeacherReunion).HasColumnName("atma_kriya_yoga_teacher_reunion");
            entity.Property(e => e.AtmaKriyaYogaTeacherRomania).HasColumnName("atma_kriya_yoga_teacher_romania");
            entity.Property(e => e.AtmaKriyaYogaTeacherRussia).HasColumnName("atma_kriya_yoga_teacher_russia");
            entity.Property(e => e.AtmaKriyaYogaTeacherSerbia).HasColumnName("atma_kriya_yoga_teacher_serbia");
            entity.Property(e => e.AtmaKriyaYogaTeacherSingapore).HasColumnName("atma_kriya_yoga_teacher_singapore");
            entity.Property(e => e.AtmaKriyaYogaTeacherSlovakia).HasColumnName("atma_kriya_yoga_teacher_slovakia");
            entity.Property(e => e.AtmaKriyaYogaTeacherSlovenia).HasColumnName("atma_kriya_yoga_teacher_slovenia");
            entity.Property(e => e.AtmaKriyaYogaTeacherSouthAfrica).HasColumnName("atma_kriya_yoga_teacher_south_africa");
            entity.Property(e => e.AtmaKriyaYogaTeacherSpain).HasColumnName("atma_kriya_yoga_teacher_spain");
            entity.Property(e => e.AtmaKriyaYogaTeacherSpn).HasColumnName("atma_kriya_yoga_teacher_spn");
            entity.Property(e => e.AtmaKriyaYogaTeacherSwaziland).HasColumnName("atma_kriya_yoga_teacher_swaziland");
            entity.Property(e => e.AtmaKriyaYogaTeacherSwitzerland).HasColumnName("atma_kriya_yoga_teacher_switzerland");
            entity.Property(e => e.AtmaKriyaYogaTeacherTaiwan).HasColumnName("atma_kriya_yoga_teacher_taiwan");
            entity.Property(e => e.AtmaKriyaYogaTeacherTurkey).HasColumnName("atma_kriya_yoga_teacher_turkey");
            entity.Property(e => e.AtmaKriyaYogaTeacherUkraine).HasColumnName("atma_kriya_yoga_teacher_ukraine");
            entity.Property(e => e.AtmaKriyaYogaTeacherUnitedArabEmirates).HasColumnName("atma_kriya_yoga_teacher_united_arab_emirates");
            entity.Property(e => e.AtmaKriyaYogaTeacherUnitedKingdom).HasColumnName("atma_kriya_yoga_teacher_united_kingdom");
            entity.Property(e => e.AtmaKriyaYogaTeacherUnitedStates).HasColumnName("atma_kriya_yoga_teacher_united_states");
            entity.Property(e => e.AtmaKriyaYogaTeacherUruguay).HasColumnName("atma_kriya_yoga_teacher_uruguay");
            entity.Property(e => e.BecomeADevoteeStatus)
                .HasMaxLength(150)
                .HasColumnName("become_a_devotee_status");
            entity.Property(e => e.BecomeAOmcCoordinateurStatus)
                .HasMaxLength(300)
                .HasColumnName("become_a_omc_coordinateur_status");
            entity.Property(e => e.BecomeAnAtmaKriyaYogaStudentStatus)
                .HasMaxLength(150)
                .HasColumnName("become_an_atma_kriya_yoga_student_status");
            entity.Property(e => e.BrahmachariWhatYearWereYouInitiated)
                .HasMaxLength(150)
                .HasColumnName("brahmachari___what_year_were_you_initiated_");
            entity.Property(e => e.City)
                .HasMaxLength(500)
                .HasColumnName("city");
            entity.Property(e => e.CitySOrVillageSWhereYouWillOrganizeOmChantingCircles).HasColumnName("city_s__or_village_s__where_you_will_organize_om_chanting_circles");
            entity.Property(e => e.CommentOmcStudent).HasColumnName("comment_omc_student");
            entity.Property(e => e.CommentOmcTeacher).HasColumnName("comment_omc_teacher");
            entity.Property(e => e.CommentStudent).HasColumnName("comment_student");
            entity.Property(e => e.CommentTeacher).HasColumnName("comment_teacher");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.CompletedDevoteeCourse)
                .HasMaxLength(50)
                .HasColumnName("completed_devotee_course");
            entity.Property(e => e.Consent).HasColumnName("consent_");
            entity.Property(e => e.Consent1)
                .HasMaxLength(50)
                .HasColumnName("consent_1");
            entity.Property(e => e.ConsentBecomeADevoteeDataSharing)
                .HasMaxLength(50)
                .HasColumnName("consent_become_a_devotee___data_sharing");
            entity.Property(e => e.ConsentCollectAndProcessMyDataToInsertThisDataIntoOurDatabase).HasColumnName("consent_collect_and_process_my_data_to_insert_this_data_into_our_database");
            entity.Property(e => e.ConsentFindAnAtmaKriyaYogaTeacher)
                .HasMaxLength(50)
                .HasColumnName("consent___find_an_atma_kriya_yoga_teacher");
            entity.Property(e => e.ConsentForTheTrainingOfOmChantingOrganisersForMySpiritualNameToBeGiven).HasColumnName("consent_for_the_training_of__om_chanting_organisers__for_my_spiritual_name_to_be_given");
            entity.Property(e => e.ConsentTransferDataToBmicAndOmChantingCoordinators)
                .HasMaxLength(50)
                .HasColumnName("consent_transfer_data_to_bmic_and_om_chanting_coordinators");
            entity.Property(e => e.ContactStatus).HasColumnName("contact_status");
            entity.Property(e => e.CountryAtmaKriyaYoga).HasColumnName("country_atma_kriya_yoga");
            entity.Property(e => e.CountryCalculated)
                .HasMaxLength(300)
                .HasColumnName("country_calculated");
            entity.Property(e => e.CountryOfResidence).HasColumnName("country_of_residence");
            entity.Property(e => e.DateAtmaKriyaYogaCourse).HasColumnName("date_atma_kriya_yoga_course");
            entity.Property(e => e.DateBlessingOmc).HasColumnName("date_blessing_omc");
            entity.Property(e => e.DateOfBirthDatePicker).HasColumnName("date_of_birth_date_picker");
            entity.Property(e => e.DateRequestBecomeADevotee).HasColumnName("date_request___become_a_devotee");
            entity.Property(e => e.DateRequestBecomeAnAtmaKriyaYogaStudent).HasColumnName("date_request_become_an_atma_kriya_yoga_student");
            entity.Property(e => e.DateRequestOmcBlessing)
                .HasMaxLength(150)
                .HasColumnName("date_request___omc_blessing");
            entity.Property(e => e.DevoteeApprovedByTheResponsibleSwamiNi).HasColumnName("devotee_approved_by_the_responsible_swami_ni");
            entity.Property(e => e.DoYouAlreadyHaveAPotentialGroupOfParticipants)
                .HasMaxLength(50)
                .HasColumnName("do_you_already_have_a_potential_group_of_participants_");
            entity.Property(e => e.DoYouHaveACopyOfAnyOfTheFollowingBooks).HasColumnName("do_you_have_a_copy_of_any_of_the_following_books_");
            entity.Property(e => e.DoYouHaveASevaRoleForBmInYourCountry)
                .HasMaxLength(300)
                .HasColumnName("do_you_have_a_seva_role_for_bm_in_your_country_");
            entity.Property(e => e.DoYouSpeakEnglish).HasColumnName("do_you_speak_english_");
            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(300)
                .HasColumnName("firstname");
            entity.Property(e => e.GdprConsentForSwamiBmccCommunication)
                .HasMaxLength(350)
                .HasColumnName("gdpr___consent_for_swami_bmcc_communication");
            entity.Property(e => e.Gender)
                .HasMaxLength(150)
                .HasColumnName("gender__");
            entity.Property(e => e.Gender1)
                .HasMaxLength(150)
                .HasColumnName("gender");
            entity.Property(e => e.GformAreYouABhaktiMargaTeacher).HasColumnName("gform___are_you_a_bhakti_marga_teacher_");
            entity.Property(e => e.HasFilledTheDevoteeApplicationForm)
                .HasMaxLength(150)
                .HasColumnName("has_filled_the_devotee_application_form");
            entity.Property(e => e.HaveYouDoneTheAtmaKriyaYogaCourse)
                .HasMaxLength(50)
                .HasColumnName("have_you_done_the_atma_kriya_yoga_course_");
            entity.Property(e => e.HaveYouTakenStudyTheDevoteeCourse)
                .HasMaxLength(50)
                .HasColumnName("have_you_taken_study_the_devotee_course");
            entity.Property(e => e.HaveYouTakenTheOmChantingWorkshop)
                .HasMaxLength(50)
                .HasColumnName("have_you_taken_the_om_chanting_workshop_");
            entity.Property(e => e.HowManyOmChantingCirclesHaveYouParticipatedIn).HasColumnName("how_many_om_chanting_circles_have_you_participated_in_");
            entity.Property(e => e.HsLanguage)
                .HasMaxLength(350)
                .HasColumnName("hs_language");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InitiatedDevoteeOfParamahamsaVishwandaYNRadio).HasColumnName("initiated_devotee_of_paramahamsa_vishwanda_y_n__radio_");
            entity.Property(e => e.IshtaDev).HasColumnName("ishta_dev");
            entity.Property(e => e.LastCourseCompletedDate).HasColumnName("last_course_completed_date");
            entity.Property(e => e.Lastname)
                .HasMaxLength(300)
                .HasColumnName("lastname");
            entity.Property(e => e.MergedDataHubConsents)
                .HasMaxLength(50)
                .HasColumnName("merged_data_hub_consents");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(150)
                .HasColumnName("mobilephone");
            entity.Property(e => e.NameAndContactOfTheOmcTeacher).HasColumnName("name_and_contact_of_the_omc_teacher");
            entity.Property(e => e.Nationality)
                .HasMaxLength(400)
                .HasColumnName("nationality_");
            entity.Property(e => e.NotBlessedStatus)
                .HasMaxLength(50)
                .HasColumnName("not_blessed_status");
            entity.Property(e => e.NotesForSwamiBecomeADevotee).HasColumnName("notes_for_swami___become_a_devotee");
            entity.Property(e => e.OmcAcCountriesUnderTheirResponsibility)
                .HasMaxLength(300)
                .HasColumnName("omc_ac___countries_under_their__responsibility");
            entity.Property(e => e.OtherSkillsAndQualitiesYouCouldOfferAsSevaForBhaktiMargaInYourCountry).HasColumnName("other_skills_and_qualities_you_could_offer_as_seva_for_bhakti_marga_in_your_country_");
            entity.Property(e => e.PaymentAtmaKriyaYogaCourse)
                .HasMaxLength(150)
                .HasColumnName("payment_atma_kriya_yoga_course");
            entity.Property(e => e.Phone)
                .HasMaxLength(150)
                .HasColumnName("phone");
            entity.Property(e => e.Picture).HasColumnName("picture");
            entity.Property(e => e.PreferedSwamiRishi).HasColumnName("prefered_swami_rishi");
            entity.Property(e => e.Profession)
                .HasMaxLength(450)
                .HasColumnName("profession");
            entity.Property(e => e.QuitDevoteeDate)
                .HasMaxLength(150)
                .HasColumnName("quit_devotee_date");
            entity.Property(e => e.QuitDevoteeStatus)
                .HasMaxLength(150)
                .HasColumnName("quit_devotee_status");
            entity.Property(e => e.Read)
                .HasMaxLength(50)
                .HasColumnName("read");
            entity.Property(e => e.Role)
                .HasMaxLength(300)
                .HasColumnName("role");
            entity.Property(e => e.Shaktipat).HasColumnName("shaktipat");
            entity.Property(e => e.SinceHowLongYouFollowTheTeachingsOfPv).HasColumnName("since_how_long_you_follow_the_teachings__of_pv");
            entity.Property(e => e.SpiritualName)
                .HasMaxLength(300)
                .HasColumnName("spiritual_name");
            entity.Property(e => e.State)
                .HasMaxLength(400)
                .HasColumnName("state");
            entity.Property(e => e.SwamiCountriesUnderTheirResponsability)
                .HasMaxLength(500)
                .HasColumnName("swami___countries_under_their__responsability");
            entity.Property(e => e.TeacherArt)
                .HasMaxLength(300)
                .HasColumnName("teacher___art");
            entity.Property(e => e.TeacherKnowledge)
                .HasMaxLength(300)
                .HasColumnName("teacher___knowledge");
            entity.Property(e => e.TeacherMusic)
                .HasMaxLength(300)
                .HasColumnName("teacher___music");
            entity.Property(e => e.TeacherRituals)
                .HasMaxLength(300)
                .HasColumnName("teacher___rituals");
            entity.Property(e => e.TeacherYogaMeditation)
                .HasMaxLength(300)
                .HasColumnName("teacher___yoga___meditation");
            entity.Property(e => e.TransferDataToResponsibleCountrySwami)
                .HasMaxLength(50)
                .HasColumnName("transfer_data_to_responsible_country_swami");
            entity.Property(e => e.VerifiedArtTeacher).HasColumnName("verified_art_teacher");
            entity.Property(e => e.VerifiedKnowledgeTeachers)
                .HasMaxLength(50)
                .HasColumnName("verified_knowledge_teachers");
            entity.Property(e => e.VerifiedMusic).HasColumnName("verified_music");
            entity.Property(e => e.VerifiedRitualsTeacher).HasColumnName("verified_rituals_teacher");
            entity.Property(e => e.VerifiedTeachers).HasColumnName("verified_teachers");
            entity.Property(e => e.VerifiedYogaAndMeditationTeachers).HasColumnName("verified_yoga_and_meditation_teachers");
            entity.Property(e => e.WhatAreTheSkillsAndQualitiesYouCouldOffer).HasColumnName("what_are_the_skills_and_qualities_you_could_offer_");
            entity.Property(e => e.WhatIsYourBhaktiMargaRoleInYourCountry)
                .HasMaxLength(300)
                .HasColumnName("what_is_your_bhakti_marga_role_in_your_country");
            entity.Property(e => e.WhatLevel)
                .HasMaxLength(50)
                .HasColumnName("what_level_");
            entity.Property(e => e.WhatRoleDoYouHaveInBhaktiMarga)
                .HasMaxLength(300)
                .HasColumnName("what_role_do_you_have_in_bhakti_marga_");
            entity.Property(e => e.WhatYearWereYouInitiated).HasColumnName("what_year_were_you_initiated_");
            entity.Property(e => e.WhoDoYouWantInitiatedYouAsDevotee)
                .HasMaxLength(300)
                .HasColumnName("who_do_you_want_initiated_you_as_devotee_");
            entity.Property(e => e.WhoInitiatedYouBrahmachariBrahmachariniDropdown)
                .HasMaxLength(300)
                .HasColumnName("who_initiated_you__brahmachari_brahmacharini__dropdown_");
            entity.Property(e => e.WhoInitiatedYouSwami)
                .HasMaxLength(150)
                .HasColumnName("who_initiated_you__swami");
            entity.Property(e => e.WhyWouldYouLikeToOrganizeOmChantingGroupS).HasColumnName("why_would_you_like_to_organize_om_chanting_group_s__");
            entity.Property(e => e.Zip).HasColumnName("zip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
