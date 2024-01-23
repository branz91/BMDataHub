using System;
using System.Collections.Generic;

namespace DataAccess.Data;

public partial class AllContactsList
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string Email { get; set; } = null!;

    public string? CountryOfResidence { get; set; }

    public string? Zip { get; set; }

    public string? Picture { get; set; }

    public string? ContactStatus { get; set; }

    public string? NotesForSwamiBecomeADevotee { get; set; }

    public string? HsLanguage { get; set; }

    public bool? DoYouSpeakEnglish { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirthDatePicker { get; set; }

    public string? Mobilephone { get; set; }

    public string? Phone { get; set; }

    public string? QuitDevoteeDate { get; set; }

    public string? QuitDevoteeStatus { get; set; }

    public DateTime? WhatYearWereYouInitiated { get; set; }

    public string? WhoInitiatedYouSwami { get; set; }

    public string? BecomeADevoteeStatus { get; set; }

    public string? HaveYouTakenStudyTheDevoteeCourse { get; set; }

    public string? Profession { get; set; }

    public DateOnly? SinceHowLongYouFollowTheTeachingsOfPv { get; set; }

    public string? WhatAreTheSkillsAndQualitiesYouCouldOffer { get; set; }

    public string? City { get; set; }

    public string? SpiritualName { get; set; }

    public bool? AreYouAvailableToDoSeva { get; set; }

    public string? Comments { get; set; }

    public string? Read { get; set; }

    public DateOnly? DateRequestBecomeADevotee { get; set; }

    public string? HasFilledTheDevoteeApplicationForm { get; set; }

    public string? CompletedDevoteeCourse { get; set; }

    public string? SwamiCountriesUnderTheirResponsability { get; set; }

    public string? DoYouHaveACopyOfAnyOfTheFollowingBooks { get; set; }

    public DateOnly? AgreedDateOfInitiationWithYourSwamiRishi { get; set; }

    public bool? PreferedSwamiRishi { get; set; }

    public string? State { get; set; }

    public string? Nationality { get; set; }

    public string? Gender1 { get; set; }

    public bool? DevoteeApprovedByTheResponsibleSwamiNi { get; set; }

    public bool? InitiatedDevoteeOfParamahamsaVishwandaYNRadio { get; set; }

    public string? IshtaDev { get; set; }

    public bool? AreYouABrahmachariBrahmachariniRadio { get; set; }

    public string? BrahmachariWhatYearWereYouInitiated { get; set; }

    public string? WhoInitiatedYouBrahmachariBrahmachariniDropdown { get; set; }

    public string? WhoDoYouWantInitiatedYouAsDevotee { get; set; }

    public bool? GformAreYouABhaktiMargaTeacher { get; set; }

    public string? TeacherArt { get; set; }

    public string? TeacherKnowledge { get; set; }

    public string? TeacherMusic { get; set; }

    public string? TeacherRituals { get; set; }

    public string? TeacherYogaMeditation { get; set; }

    public string? DoYouHaveASevaRoleForBmInYourCountry { get; set; }

    public string? OtherSkillsAndQualitiesYouCouldOfferAsSevaForBhaktiMargaInYourCountry { get; set; }

    public string? WhatIsYourBhaktiMargaRoleInYourCountry { get; set; }

    public string? WhatRoleDoYouHaveInBhaktiMarga { get; set; }

    public string? Role { get; set; }

    public string? CountryCalculated { get; set; }

    public string? MergedDataHubConsents { get; set; }

    public string? ConsentBecomeADevoteeDataSharing { get; set; }

    public string? TransferDataToResponsibleCountrySwami { get; set; }

    public string? GdprConsentForSwamiBmccCommunication { get; set; }

    public string? ConsentFindAnAtmaKriyaYogaTeacher { get; set; }

    public string? Consent1 { get; set; }

    public DateOnly? LastCourseCompletedDate { get; set; }

    public string? AreYouInitiatedInAtmaKriyaYoga { get; set; }

    public string? AtmaKriyaWhatYearWereYouInitiated { get; set; }

    public string? BecomeAnAtmaKriyaYogaStudentStatus { get; set; }

    public DateOnly? DateRequestBecomeAnAtmaKriyaYogaStudent { get; set; }

    public string? PaymentAtmaKriyaYogaCourse { get; set; }

    public string? CommentStudent { get; set; }

    public string? CommentTeacher { get; set; }

    public bool? Shaktipat { get; set; }

    public string? HaveYouDoneTheAtmaKriyaYogaCourse { get; set; }

    public DateOnly? DateAtmaKriyaYogaCourse { get; set; }

    public string? CountryAtmaKriyaYoga { get; set; }

    public string? WhatLevel { get; set; }

    public string? AtmaKriyaYogaTeacherAlbania { get; set; }

    public string? AtmaKriyaYogaTeacherArgentina { get; set; }

    public string? AtmaKriyaYogaTeacherAustralia { get; set; }

    public string? AtmaKriyaYogaTeacherAustria { get; set; }

    public string? AtmaKriyaYogaTeacherBelgium { get; set; }

    public string? AtmaKriyaYogaTeacherBolivia { get; set; }

    public string? AtmaKriyaYogaTeacherBosniaAndHerzegovina { get; set; }

    public string? AtmaKriyaYogaTeacherBrazil { get; set; }

    public string? AtmaKriyaYogaTeacherBulgaria { get; set; }

    public string? AtmaKriyaYogaTeacherCambodia { get; set; }

    public string? AtmaKriyaYogaTeacherCanada { get; set; }

    public string? AtmaKriyaYogaTeacherChile { get; set; }

    public string? AtmaKriyaYogaTeacherChina { get; set; }

    public string? AtmaKriyaYogaTeacherColombia { get; set; }

    public string? AtmaKriyaYogaTeacherCoteDIvoire { get; set; }

    public string? AtmaKriyaYogaTeacherCroatia { get; set; }

    public string? AtmaKriyaYogaTeacherCzechRepublic { get; set; }

    public string? AtmaKriyaYogaTeacherDenmark { get; set; }

    public string? AtmaKriyaYogaTeacherEcuador { get; set; }

    public string? AtmaKriyaYogaTeacherEgypt { get; set; }

    public string? AtmaKriyaYogaTeacherEstonia { get; set; }

    public string? AtmaKriyaYogaTeacherFinland { get; set; }

    public string? AtmaKriyaYogaTeacherGreece { get; set; }

    public string? AtmaKriyaYogaTeacherHungary { get; set; }

    public string? AtmaKriyaYogaTeacherIndia { get; set; }

    public string? AtmaKriyaYogaTeacherIndonesia { get; set; }

    public string? AtmaKriyaYogaTeacherIreland { get; set; }

    public string? AtmaKriyaYogaTeacherItaly { get; set; }

    public string? AtmaKriyaYogaTeacherJapan { get; set; }

    public string? AtmaKriyaYogaTeacherJordan { get; set; }

    public string? AtmaKriyaYogaTeacherKenya { get; set; }

    public string? AtmaKriyaYogaTeacherLatvia { get; set; }

    public string? AtmaKriyaYogaTeacherLebanon { get; set; }

    public string? AtmaKriyaYogaTeacherLithuania { get; set; }

    public string? AtmaKriyaYogaTeacherMacedonia { get; set; }

    public string? AtmaKriyaYogaTeacherMadagascar { get; set; }

    public string? AtmaKriyaYogaTeacherMalaysia { get; set; }

    public string? AtmaKriyaYogaTeacherMauritius { get; set; }

    public string? AtmaKriyaYogaTeacherMexico { get; set; }

    public string? AtmaKriyaYogaTeacherMontenegro { get; set; }

    public string? AtmaKriyaYogaTeacherMozambique { get; set; }

    public string? AtmaKriyaYogaTeacherNepal { get; set; }

    public string? AtmaKriyaYogaTeacherNetherlands { get; set; }

    public string? AtmaKriyaYogaTeacherNewZealand { get; set; }

    public string? AtmaKriyaYogaTeacherNorway { get; set; }

    public string? AtmaKriyaYogaTeacherPeru { get; set; }

    public string? AtmaKriyaYogaTeacherPoland { get; set; }

    public string? AtmaKriyaYogaTeacherPortugal { get; set; }

    public string? AtmaKriyaYogaTeacherReunion { get; set; }

    public string? AtmaKriyaYogaTeacherRomania { get; set; }

    public string? AtmaKriyaYogaTeacherRussia { get; set; }

    public string? AtmaKriyaYogaTeacherSerbia { get; set; }

    public string? AtmaKriyaYogaTeacherSingapore { get; set; }

    public string? AtmaKriyaYogaTeacherSlovakia { get; set; }

    public string? AtmaKriyaYogaTeacherSlovenia { get; set; }

    public string? AtmaKriyaYogaTeacherSouthAfrica { get; set; }

    public string? AtmaKriyaYogaTeacherSpain { get; set; }

    public string? AtmaKriyaYogaTeacherSpn { get; set; }

    public string? AtmaKriyaYogaTeacherSwaziland { get; set; }

    public string? AtmaKriyaYogaTeacherSwitzerland { get; set; }

    public string? AtmaKriyaYogaTeacherTaiwan { get; set; }

    public string? AtmaKriyaYogaTeacherTurkey { get; set; }

    public string? AtmaKriyaYogaTeacherUkraine { get; set; }

    public string? AtmaKriyaYogaTeacherUnitedArabEmirates { get; set; }

    public string? AtmaKriyaYogaTeacherUnitedKingdom { get; set; }

    public string? AtmaKriyaYogaTeacherUnitedStates { get; set; }

    public string? AtmaKriyaYogaTeacherUruguay { get; set; }

    public string? AtmaKriyaYogaTeacherFrance { get; set; }

    public string? AtmaKriyaYogaTeacherGermany { get; set; }

    public string? AkyTeacherCalculated { get; set; }

    public string? AkyTeacherCalculatedLabel { get; set; }

    public string? AkyTeachersCountriesUnderTheirResponsibility { get; set; }

    public string? BecomeAOmcCoordinateurStatus { get; set; }

    public string? OmcAcCountriesUnderTheirResponsibility { get; set; }

    public string? CommentOmcStudent { get; set; }

    public string? CommentOmcTeacher { get; set; }

    public string? CitySOrVillageSWhereYouWillOrganizeOmChantingCircles { get; set; }

    public bool? ConsentCollectAndProcessMyDataToInsertThisDataIntoOurDatabase { get; set; }

    public bool? ConsentForTheTrainingOfOmChantingOrganisersForMySpiritualNameToBeGiven { get; set; }

    public bool? Consent { get; set; }

    public string? ConsentTransferDataToBmicAndOmChantingCoordinators { get; set; }

    public string? DoYouAlreadyHaveAPotentialGroupOfParticipants { get; set; }

    public string? HaveYouTakenTheOmChantingWorkshop { get; set; }

    public string? HowManyOmChantingCirclesHaveYouParticipatedIn { get; set; }

    public string? NameAndContactOfTheOmcTeacher { get; set; }

    public string? WhyWouldYouLikeToOrganizeOmChantingGroupS { get; set; }

    public string? NotBlessedStatus { get; set; }

    public string? DateRequestOmcBlessing { get; set; }

    public DateOnly? DateBlessingOmc { get; set; }

    public string? VerifiedTeachers { get; set; }

    public string? VerifiedArtTeacher { get; set; }

    public string? VerifiedKnowledgeTeachers { get; set; }

    public string? VerifiedMusic { get; set; }

    public string? VerifiedRitualsTeacher { get; set; }

    public string? VerifiedYogaAndMeditationTeachers { get; set; }

    public string? AdditionalEmailAddresses { get; set; }
}
