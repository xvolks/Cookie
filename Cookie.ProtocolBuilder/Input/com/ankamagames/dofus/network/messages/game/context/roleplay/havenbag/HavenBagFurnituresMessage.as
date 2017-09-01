package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag
{
   import com.ankamagames.dofus.network.types.game.guild.HavenBagFurnitureInformation;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HavenBagFurnituresMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6634;
       
      
      private var _isInitialized:Boolean = false;
      
      public var furnituresInfos:Vector.<HavenBagFurnitureInformation>;
      
      private var _furnituresInfostree:FuncTree;
      
      public function HavenBagFurnituresMessage()
      {
         this.furnituresInfos = new Vector.<HavenBagFurnitureInformation>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6634;
      }
      
      public function initHavenBagFurnituresMessage(param1:Vector.<HavenBagFurnitureInformation> = null) : HavenBagFurnituresMessage
      {
         this.furnituresInfos = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.furnituresInfos = new Vector.<HavenBagFurnitureInformation>();
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HavenBagFurnituresMessage(param1);
      }
      
      public function serializeAs_HavenBagFurnituresMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.furnituresInfos.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.furnituresInfos.length)
         {
            (this.furnituresInfos[_loc2_] as HavenBagFurnitureInformation).serializeAs_HavenBagFurnitureInformation(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HavenBagFurnituresMessage(param1);
      }
      
      public function deserializeAs_HavenBagFurnituresMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:HavenBagFurnitureInformation = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new HavenBagFurnitureInformation();
            _loc4_.deserialize(param1);
            this.furnituresInfos.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HavenBagFurnituresMessage(param1);
      }
      
      public function deserializeAsyncAs_HavenBagFurnituresMessage(param1:FuncTree) : void
      {
         this._furnituresInfostree = param1.addChild(this._furnituresInfostreeFunc);
      }
      
      private function _furnituresInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._furnituresInfostree.addChild(this._furnituresInfosFunc);
            _loc3_++;
         }
      }
      
      private function _furnituresInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:HavenBagFurnitureInformation = new HavenBagFurnitureInformation();
         _loc2_.deserialize(param1);
         this.furnituresInfos.push(_loc2_);
      }
   }
}
