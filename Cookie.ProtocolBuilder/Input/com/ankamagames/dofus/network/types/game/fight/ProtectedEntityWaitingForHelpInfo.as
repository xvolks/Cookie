package com.ankamagames.dofus.network.types.game.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ProtectedEntityWaitingForHelpInfo implements INetworkType
   {
      
      public static const protocolId:uint = 186;
       
      
      public var timeLeftBeforeFight:int = 0;
      
      public var waitTimeForPlacement:int = 0;
      
      public var nbPositionForDefensors:uint = 0;
      
      public function ProtectedEntityWaitingForHelpInfo()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 186;
      }
      
      public function initProtectedEntityWaitingForHelpInfo(param1:int = 0, param2:int = 0, param3:uint = 0) : ProtectedEntityWaitingForHelpInfo
      {
         this.timeLeftBeforeFight = param1;
         this.waitTimeForPlacement = param2;
         this.nbPositionForDefensors = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.timeLeftBeforeFight = 0;
         this.waitTimeForPlacement = 0;
         this.nbPositionForDefensors = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ProtectedEntityWaitingForHelpInfo(param1);
      }
      
      public function serializeAs_ProtectedEntityWaitingForHelpInfo(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.timeLeftBeforeFight);
         param1.writeInt(this.waitTimeForPlacement);
         if(this.nbPositionForDefensors < 0)
         {
            throw new Error("Forbidden value (" + this.nbPositionForDefensors + ") on element nbPositionForDefensors.");
         }
         param1.writeByte(this.nbPositionForDefensors);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ProtectedEntityWaitingForHelpInfo(param1);
      }
      
      public function deserializeAs_ProtectedEntityWaitingForHelpInfo(param1:ICustomDataInput) : void
      {
         this._timeLeftBeforeFightFunc(param1);
         this._waitTimeForPlacementFunc(param1);
         this._nbPositionForDefensorsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ProtectedEntityWaitingForHelpInfo(param1);
      }
      
      public function deserializeAsyncAs_ProtectedEntityWaitingForHelpInfo(param1:FuncTree) : void
      {
         param1.addChild(this._timeLeftBeforeFightFunc);
         param1.addChild(this._waitTimeForPlacementFunc);
         param1.addChild(this._nbPositionForDefensorsFunc);
      }
      
      private function _timeLeftBeforeFightFunc(param1:ICustomDataInput) : void
      {
         this.timeLeftBeforeFight = param1.readInt();
      }
      
      private function _waitTimeForPlacementFunc(param1:ICustomDataInput) : void
      {
         this.waitTimeForPlacement = param1.readInt();
      }
      
      private function _nbPositionForDefensorsFunc(param1:ICustomDataInput) : void
      {
         this.nbPositionForDefensors = param1.readByte();
         if(this.nbPositionForDefensors < 0)
         {
            throw new Error("Forbidden value (" + this.nbPositionForDefensors + ") on element of ProtectedEntityWaitingForHelpInfo.nbPositionForDefensors.");
         }
      }
   }
}
