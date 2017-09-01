package com.ankamagames.dofus.network.types.game.achievement
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class AchievementStartedObjective extends AchievementObjective implements INetworkType
   {
      
      public static const protocolId:uint = 402;
       
      
      public var value:uint = 0;
      
      public function AchievementStartedObjective()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 402;
      }
      
      public function initAchievementStartedObjective(param1:uint = 0, param2:uint = 0, param3:uint = 0) : AchievementStartedObjective
      {
         super.initAchievementObjective(param1,param2);
         this.value = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.value = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AchievementStartedObjective(param1);
      }
      
      public function serializeAs_AchievementStartedObjective(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AchievementObjective(param1);
         if(this.value < 0)
         {
            throw new Error("Forbidden value (" + this.value + ") on element value.");
         }
         param1.writeVarShort(this.value);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AchievementStartedObjective(param1);
      }
      
      public function deserializeAs_AchievementStartedObjective(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._valueFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AchievementStartedObjective(param1);
      }
      
      public function deserializeAsyncAs_AchievementStartedObjective(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._valueFunc);
      }
      
      private function _valueFunc(param1:ICustomDataInput) : void
      {
         this.value = param1.readVarUhShort();
         if(this.value < 0)
         {
            throw new Error("Forbidden value (" + this.value + ") on element of AchievementStartedObjective.value.");
         }
      }
   }
}
