package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionAlliance extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 425;
       
      
      public var allianceInformations:AllianceInformations;
      
      public var aggressable:uint = 0;
      
      private var _allianceInformationstree:FuncTree;
      
      public function HumanOptionAlliance()
      {
         this.allianceInformations = new AllianceInformations();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 425;
      }
      
      public function initHumanOptionAlliance(param1:AllianceInformations = null, param2:uint = 0) : HumanOptionAlliance
      {
         this.allianceInformations = param1;
         this.aggressable = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.allianceInformations = new AllianceInformations();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionAlliance(param1);
      }
      
      public function serializeAs_HumanOptionAlliance(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         this.allianceInformations.serializeAs_AllianceInformations(param1);
         param1.writeByte(this.aggressable);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionAlliance(param1);
      }
      
      public function deserializeAs_HumanOptionAlliance(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.allianceInformations = new AllianceInformations();
         this.allianceInformations.deserialize(param1);
         this._aggressableFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionAlliance(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionAlliance(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._allianceInformationstree = param1.addChild(this._allianceInformationstreeFunc);
         param1.addChild(this._aggressableFunc);
      }
      
      private function _allianceInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.allianceInformations = new AllianceInformations();
         this.allianceInformations.deserializeAsync(this._allianceInformationstree);
      }
      
      private function _aggressableFunc(param1:ICustomDataInput) : void
      {
         this.aggressable = param1.readByte();
         if(this.aggressable < 0)
         {
            throw new Error("Forbidden value (" + this.aggressable + ") on element of HumanOptionAlliance.aggressable.");
         }
      }
   }
}
