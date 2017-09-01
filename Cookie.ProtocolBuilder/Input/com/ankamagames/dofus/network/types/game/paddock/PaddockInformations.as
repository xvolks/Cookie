package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PaddockInformations implements INetworkType
   {
      
      public static const protocolId:uint = 132;
       
      
      public var maxOutdoorMount:uint = 0;
      
      public var maxItems:uint = 0;
      
      public function PaddockInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 132;
      }
      
      public function initPaddockInformations(param1:uint = 0, param2:uint = 0) : PaddockInformations
      {
         this.maxOutdoorMount = param1;
         this.maxItems = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.maxOutdoorMount = 0;
         this.maxItems = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockInformations(param1);
      }
      
      public function serializeAs_PaddockInformations(param1:ICustomDataOutput) : void
      {
         if(this.maxOutdoorMount < 0)
         {
            throw new Error("Forbidden value (" + this.maxOutdoorMount + ") on element maxOutdoorMount.");
         }
         param1.writeVarShort(this.maxOutdoorMount);
         if(this.maxItems < 0)
         {
            throw new Error("Forbidden value (" + this.maxItems + ") on element maxItems.");
         }
         param1.writeVarShort(this.maxItems);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockInformations(param1);
      }
      
      public function deserializeAs_PaddockInformations(param1:ICustomDataInput) : void
      {
         this._maxOutdoorMountFunc(param1);
         this._maxItemsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockInformations(param1);
      }
      
      public function deserializeAsyncAs_PaddockInformations(param1:FuncTree) : void
      {
         param1.addChild(this._maxOutdoorMountFunc);
         param1.addChild(this._maxItemsFunc);
      }
      
      private function _maxOutdoorMountFunc(param1:ICustomDataInput) : void
      {
         this.maxOutdoorMount = param1.readVarUhShort();
         if(this.maxOutdoorMount < 0)
         {
            throw new Error("Forbidden value (" + this.maxOutdoorMount + ") on element of PaddockInformations.maxOutdoorMount.");
         }
      }
      
      private function _maxItemsFunc(param1:ICustomDataInput) : void
      {
         this.maxItems = param1.readVarUhShort();
         if(this.maxItems < 0)
         {
            throw new Error("Forbidden value (" + this.maxItems + ") on element of PaddockInformations.maxItems.");
         }
      }
   }
}
