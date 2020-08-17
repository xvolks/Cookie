package com.ankamagames.dofus.network.types.game.paddock
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PaddockInstancesInformations extends PaddockInformations implements INetworkType
   {
      
      public static const protocolId:uint = 509;
       
      
      public var paddocks:Vector.<PaddockBuyableInformations>;
      
      private var _paddockstree:FuncTree;
      
      public function PaddockInstancesInformations()
      {
         this.paddocks = new Vector.<PaddockBuyableInformations>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 509;
      }
      
      public function initPaddockInstancesInformations(param1:uint = 0, param2:uint = 0, param3:Vector.<PaddockBuyableInformations> = null) : PaddockInstancesInformations
      {
         super.initPaddockInformations(param1,param2);
         this.paddocks = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.paddocks = new Vector.<PaddockBuyableInformations>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PaddockInstancesInformations(param1);
      }
      
      public function serializeAs_PaddockInstancesInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PaddockInformations(param1);
         param1.writeShort(this.paddocks.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.paddocks.length)
         {
            param1.writeShort((this.paddocks[_loc2_] as PaddockBuyableInformations).getTypeId());
            (this.paddocks[_loc2_] as PaddockBuyableInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockInstancesInformations(param1);
      }
      
      public function deserializeAs_PaddockInstancesInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:PaddockBuyableInformations = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(PaddockBuyableInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.paddocks.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockInstancesInformations(param1);
      }
      
      public function deserializeAsyncAs_PaddockInstancesInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._paddockstree = param1.addChild(this._paddockstreeFunc);
      }
      
      private function _paddockstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._paddockstree.addChild(this._paddocksFunc);
            _loc3_++;
         }
      }
      
      private function _paddocksFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:PaddockBuyableInformations = ProtocolTypeManager.getInstance(PaddockBuyableInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.paddocks.push(_loc3_);
      }
   }
}
