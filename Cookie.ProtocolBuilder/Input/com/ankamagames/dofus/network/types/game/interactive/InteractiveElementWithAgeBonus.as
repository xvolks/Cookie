package com.ankamagames.dofus.network.types.game.interactive
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class InteractiveElementWithAgeBonus extends InteractiveElement implements INetworkType
   {
      
      public static const protocolId:uint = 398;
       
      
      public var ageBonus:int = 0;
      
      public function InteractiveElementWithAgeBonus()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 398;
      }
      
      public function initInteractiveElementWithAgeBonus(param1:uint = 0, param2:int = 0, param3:Vector.<InteractiveElementSkill> = null, param4:Vector.<InteractiveElementSkill> = null, param5:Boolean = false, param6:int = 0) : InteractiveElementWithAgeBonus
      {
         super.initInteractiveElement(param1,param2,param3,param4,param5);
         this.ageBonus = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.ageBonus = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_InteractiveElementWithAgeBonus(param1);
      }
      
      public function serializeAs_InteractiveElementWithAgeBonus(param1:ICustomDataOutput) : void
      {
         super.serializeAs_InteractiveElement(param1);
         if(this.ageBonus < -1 || this.ageBonus > 1000)
         {
            throw new Error("Forbidden value (" + this.ageBonus + ") on element ageBonus.");
         }
         param1.writeShort(this.ageBonus);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InteractiveElementWithAgeBonus(param1);
      }
      
      public function deserializeAs_InteractiveElementWithAgeBonus(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._ageBonusFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InteractiveElementWithAgeBonus(param1);
      }
      
      public function deserializeAsyncAs_InteractiveElementWithAgeBonus(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._ageBonusFunc);
      }
      
      private function _ageBonusFunc(param1:ICustomDataInput) : void
      {
         this.ageBonus = param1.readShort();
         if(this.ageBonus < -1 || this.ageBonus > 1000)
         {
            throw new Error("Forbidden value (" + this.ageBonus + ") on element of InteractiveElementWithAgeBonus.ageBonus.");
         }
      }
   }
}
