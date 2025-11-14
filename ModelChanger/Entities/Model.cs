namespace ModelChanger.Entities;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ModelType Type { get; set; }
    public string Area { get; set; }
    public string SystemPrompt { get; set; }

    public enum ModelType
    {
        Gpt35,
        Gpt4,
        Gpt4Turbo,
        GeminiX,
        Claude2,
        LLaMa3,
        Mpt7B,
        Falcon40B,
        Bard
    }

}