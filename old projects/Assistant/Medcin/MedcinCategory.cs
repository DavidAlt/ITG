using System.Collections.Generic;

namespace GlacialSystems.ITG
{
    public static class MedcinCategory
    {
        public enum Tier1
        {
            ChiefComplaint,
            HistoryOfPresentIllness,
            Allergies,
            CurrentMedication,
            Vaccinations,
            PastMedicalSurgicalHistory,
            PersonalHistory,
            FamilyHistory,
            ReviewOfSystems,
            PhysicalFindings,
            Tests,
            PreviousTests,
            Therapy,
            PracticeManagement
        };

        public enum Tier2
        {
            // Review of systems
            ROS_Systemic,
            ROS_Head,
            ROS_Neck,
            ROS_Eyes,
            ROS_Otolaryngeal,
            ROS_Breasts,
            ROS_Cardiovascular,
            ROS_Pulmonary,
            ROS_Gastrointestinal,
            ROS_Genitourinary,
            ROS_Endocrine,
            ROS_Hematologic,
            ROS_Musculoskeletal,
            ROS_Neurological,
            ROS_Psychological,
            ROS_Skin,
            // Physical findings
            EXAM_General,
            EXAM_VitalSigns,
            EXAM_GeneralAppearance,
            EXAM_Head, // unverified existence
            EXAM_Neck,
            EXAM_Eyes,
            EXAM_Ears,
            EXAM_Nose,
            EXAM_Pharynx,
            EXAM_Breasts,
            EXAM_Lungs,
            EXAM_Cardiovascular,
            EXAM_Abdomen,
            EXAM_Genitalia, //double-check - there might be separate sections for male/female genitalia
            EXAM_MusculoskeletalSystem,
            EXAM_Neurological,
            EXAM_Psychiatric,
            EXAM_Skin,
            // Tests
            TEST_Imaging,


        };

        public static Dictionary<Tier1, string> Section = new Dictionary<Tier1, string>
        {
            {Tier1.ChiefComplaint, "Chief complaint"},
            {Tier1.HistoryOfPresentIllness, "History of present illness"},
            {Tier1.Allergies, "Allergies"},
            {Tier1.CurrentMedication, "Current medication"},
            {Tier1.Vaccinations, "Vaccinations"},
            {Tier1.PastMedicalSurgicalHistory, "Past medical/surgical history"},
            {Tier1.PersonalHistory, "Personal history"},
            {Tier1.FamilyHistory, "Family history"},
            {Tier1.ReviewOfSystems, "Review of systems"},
            {Tier1.PhysicalFindings, "Physical findings"},
            {Tier1.Tests, "Tests"},
            {Tier1.PreviousTests, "Previous tests"},
            {Tier1.Therapy, "Therapy"},
            {Tier1.PracticeManagement, "Practice management"}
        };

        public static Dictionary<Tier2, string> ReviewOfSystems = new Dictionary<Tier2, string>
        {
            {Tier2.ROS_Systemic, "Systemic:"},
            {Tier2.ROS_Head, "Head:"},
            {Tier2.ROS_Neck, "Neck:"},
            {Tier2.ROS_Eyes, "Eyes:"},
            {Tier2.ROS_Otolaryngeal, "Otolaryngeal:"},
            {Tier2.ROS_Breasts, "Breasts:"},
            {Tier2.ROS_Cardiovascular, "Cardiovascular:"},
            {Tier2.ROS_Pulmonary, "Pulmonary:"},
            {Tier2.ROS_Gastrointestinal, "Gastrointestinal:"},
            {Tier2.ROS_Genitourinary, "Genitourinary:"},
            {Tier2.ROS_Endocrine, "Endocrine:"},
            {Tier2.ROS_Hematologic, "Hematologic:"},
            {Tier2.ROS_Musculoskeletal, "Musculoskeletal:"},
            {Tier2.ROS_Neurological, "Neurological:"},
            {Tier2.ROS_Psychological, "Psychological:"},
            {Tier2.ROS_Skin, "Skin:"}
        };

        public static Dictionary<Tier2, string> PhysicalFindings = new Dictionary<Tier2, string>
        {
            {Tier2.EXAM_General, "General:"},
            {Tier2.EXAM_VitalSigns, "Vital Signs:"},
            {Tier2.EXAM_GeneralAppearance, "General Appearnce:"},
            {Tier2.EXAM_Head, "Head:"},
            {Tier2.EXAM_Neck, "Neck:"},
            {Tier2.EXAM_Eyes, "Eyes:"},
            {Tier2.EXAM_Ears, "Ears:"},
            {Tier2.EXAM_Nose, "Nose:"},
            {Tier2.EXAM_Pharynx, "Pharynx:"},
            {Tier2.EXAM_Breasts, "Breasts:"},
            {Tier2.EXAM_Lungs, "Lungs:"},
            {Tier2.EXAM_Cardiovascular, "Cardiovascular:"},
            {Tier2.EXAM_Abdomen, "Abdomen:"},
            {Tier2.EXAM_Genitalia,  "Genitalia:"},
            {Tier2.EXAM_MusculoskeletalSystem, "Musculoskeletal System:"},
            {Tier2.EXAM_Neurological, "Neurological:"},
            {Tier2.EXAM_Psychiatric, "Psychiatric:"},
            {Tier2.EXAM_Skin, "Skin:"}
        };
    }
}

    /*
    public abstract class MedcinCategory
    {
        public MedcinCategory Parent { get; set; }
        public string Header { get; set; }
        
        public void MedcinCategory(string header, MedcinCategory parent)
        {
            this.Header = header;
            this.Parent = parent;
        }
        
        public override string ToString() 
        {
            return Header;
        }
    }

    public class Tier1 : MedcinCategory
    {
        public void Tier1(string header)
        {
            this.Header = header;
            this.Parent = null;
        }
    }

    public class Tier2 : MedcinCategory { }
     */