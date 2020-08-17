package com.ankamagames.dofus.datacenter.quest.objectives
{
   import com.ankamagames.dofus.datacenter.idols.Idol;
   import com.ankamagames.dofus.datacenter.monsters.Monster;
   import com.ankamagames.dofus.datacenter.quest.QuestObjective;
   import com.ankamagames.jerakine.data.I18n;
   import com.ankamagames.jerakine.interfaces.IDataCenter;
   import com.ankamagames.jerakine.utils.pattern.PatternDecoder;
   
   public class QuestObjectiveFightMonster extends QuestObjective implements IDataCenter
   {
       
      
      private var _monster:Monster;
      
      private var _text:String;
      
      public function QuestObjectiveFightMonster()
      {
         super();
      }
      
      public function get monsterId() : uint
      {
         if(!this.parameters)
         {
            return 0;
         }
         return this.parameters[0];
      }
      
      public function get monster() : Monster
      {
         if(!this._monster)
         {
            this._monster = Monster.getMonsterById(this.monsterId);
         }
         return this._monster;
      }
      
      public function get quantity() : uint
      {
         if(!this.parameters)
         {
            return 0;
         }
         return this.parameters[1];
      }
      
      public function get idolsScore() : uint
      {
         if(this.parameters && this.parameters.length > 2)
         {
            return this.parameters[2];
         }
         return 0;
      }
      
      public function get dungeonOnly() : Boolean
      {
         if(!this.parameters)
         {
            return false;
         }
         return parameters.dungeonOnly;
      }
      
      public function get idolId() : uint
      {
         if(this.parameters && this.parameters.length > 4)
         {
            return this.parameters[4];
         }
         return 0;
      }
      
      override public function get text() : String
      {
         var _loc1_:* = null;
         var _loc2_:Idol = null;
         if(!this._text)
         {
            _loc1_ = "{chatmonster," + this.monsterId + "}";
            if(this.idolsScore == 0 && this.idolId == 0)
            {
               this._text = PatternDecoder.getDescription(this.type.name,[_loc1_,this.quantity]);
            }
            else if(this.idolsScore > 0 && this.idolId == 0)
            {
               this._text = I18n.getUiText("ui.grimoire.quest.objectives.type6.score",[this.quantity,_loc1_,this.idolsScore]);
            }
            else if(this.idolsScore > 0 && this.idolId > 0)
            {
               _loc2_ = Idol.getIdolById(this.idolId);
               this._text = I18n.getUiText("ui.grimoire.quest.objectives.type6.scoreAndIdol",[this.quantity,_loc1_,"{item," + _loc2_.itemId + "}",this.idolsScore]);
            }
         }
         return this._text;
      }
   }
}
